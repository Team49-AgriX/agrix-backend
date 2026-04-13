using Domain.Enums;
using Service.Interface;

namespace Service.Implementation;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://my-api.plantnet.org/v2";

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<HealthStatus> CheckApiHealth()
    {
        var url = $"{BaseUrl}/_status";

        var response = await _httpClient.GetAsync(url);
        
        return response.IsSuccessStatusCode ? HealthStatus.Healthy : HealthStatus.Unhealthy;
    }
}