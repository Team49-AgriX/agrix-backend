using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Domain.Dto;
using Domain.Enums;
using Domain.Models.DiseaseID;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Service.Interface;

namespace Service.Implementation;

public class DiseaseService : IDiseaseService
{
    
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private const string BaseUrl = "https://my-api.plantnet.org/v2";
    private readonly string _geminiApiKey;
    private readonly IHistoryService _historyService;

    public DiseaseService(HttpClient httpClient, IConfiguration configuration, IHistoryService historyService)
    {
        _httpClient = httpClient;
        _historyService = historyService;
        _apiKey = configuration["PlantNet:ApiKey"] ??
                  throw new InvalidOperationException("PlantNet API key is not configured.");
        _geminiApiKey = configuration["Gemini:ApiKey"] ??
                        throw new InvalidOperationException("Gemini API key is not configured.");
    }
    
    public async Task<string> IdentifyAsync(string userId, IFormFile[] images, Organ[] organs, DiseaseIdDto queryDto)
    {
        var organList = organs.Length == images.Length 
            ? organs 
            : images.Select(_ => Organ.auto).ToArray();

        using var form = new MultipartFormDataContent();

        for (int i = 0; i < images.Length; i++)
        {
            var image = images[i];
            var imageContent = new StreamContent(image.OpenReadStream());
            imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);
            form.Add(imageContent, "images", image.FileName);
            form.Add(new StringContent(organList[i].ToString()), "organs"); 
        }

        var queryString = new StringBuilder();
        queryString.Append($"?api-key={_apiKey}");
        queryString.Append($"&lang={queryDto.Language}");
        queryString.Append($"&include-related-images={queryDto.IncludeRelatedImages.ToString().ToLower()}");
        queryString.Append($"&no-reject={queryDto.NoReject.ToString().ToLower()}");
        queryString.Append($"&nb-results={queryDto.NumResult}");

        var url = $"{BaseUrl}/diseases/identify{queryString}";

        var response = await _httpClient.PostAsync(url, form);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"PlantNet API error: {response.StatusCode} - {error}");
        }

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<Disease>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        var disease = await GetDiseaseInfoAsync(result);

        await _historyService.SaveDiseaseScanAsync(userId, disease);

        return disease;
    }

    public async Task<string> GetDiseaseInfoAsync(Disease disease, CancellationToken cancellationToken = default)
    {
        var topResult = disease?.Results?.FirstOrDefault();
        if (topResult == null)
            return "Could not identify disease";
        
        var prompt = $"""
                          A plant disease was identified with the following details:
                          - Disease name: {topResult.Name}
                          - Description: {topResult.Description}
                          - Confidence score: {topResult.Score:P1}

                          Please provide information about this disease covering:
                          - What is this disease
                          - What causes it (fungal, bacterial, viral, pest, etc.)
                          - What are the typical symptoms
                          - How to treat it
                          - How to prevent it in the future
                      """;
        
        var requestBody = new
        {
            contents = new[]
            {
                new { parts = new[] { new { text = prompt } } }
            }
        };
        
        var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={_geminiApiKey}";

        const int maxRetries = 2;
        int delayMs = 5000;
        const int maxDelayMs = 30000;

        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                using var response = await _httpClient.PostAsJsonAsync(url, requestBody, cancellationToken);

                // success
                if (response.IsSuccessStatusCode)
                {
                    await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                    using var doc = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);

                    var root = doc.RootElement;

                    if (root.TryGetProperty("candidates", out var candidates) &&
                        candidates.GetArrayLength() > 0 &&
                        candidates[0].TryGetProperty("content", out var content) &&
                        content.TryGetProperty("parts", out var parts) &&
                        parts.GetArrayLength() > 0)
                    {
                        return parts[0].GetProperty("text").GetString() ?? "Empty response from AI.";
                    }

                    return "Unexpected response format from AI service.";
                }

                // rate limit handling
                if ((int)response.StatusCode == 429)
                {
                    if (attempt == maxRetries)
                        break;

                    int waitMs = delayMs;

                    if (response.Headers.TryGetValues("Retry-After", out var values) && int.TryParse(values.FirstOrDefault(), out var retryAfterSeconds))
                    {
                        waitMs = retryAfterSeconds * 1000;
                    }

                    await Task.Delay(waitMs, cancellationToken);
                    delayMs = Math.Min(delayMs * 2, maxDelayMs);
                    continue;
                }

                // server errors
                if ((int)response.StatusCode >= 500)
                {
                    if (attempt == maxRetries)
                        break;

                    await Task.Delay(delayMs, cancellationToken);
                    delayMs = Math.Min(delayMs * 2, maxDelayMs);
                    continue;
                }

                // client errors
                var errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
                return $"AI API error ({response.StatusCode}): {errorBody}";
            }
            catch (TaskCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                // timeout
                if (attempt == maxRetries)
                    return "AI request timed out repeatedly.";

                await Task.Delay(delayMs, cancellationToken);
                delayMs = Math.Min(delayMs * 2, maxDelayMs);
            }
            catch (HttpRequestException ex)
            {
                // network issues
                if (attempt == maxRetries)
                    return $"Network error: {ex.Message}";

                await Task.Delay(delayMs, cancellationToken);
                delayMs = Math.Min(delayMs * 2, maxDelayMs);
            }
        }
        
        return "AI service is currently unavailable (rate limit or quota exceeded). Try again later.";
    }
}