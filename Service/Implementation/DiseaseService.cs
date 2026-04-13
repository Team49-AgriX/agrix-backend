using System.Net.Http.Headers;
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

    public DiseaseService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["PlantNet:ApiKey"] ??
                  throw new InvalidOperationException("PlantNet API key is not configured.");
    }
    
    public async Task<Disease> IdentifyAsync(IFormFile[] images, Organ[] organs, DiseaseIdDto queryDto)
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

        return result ?? throw new InvalidOperationException("Failed to deserialize PlantNet response.");
    }
}