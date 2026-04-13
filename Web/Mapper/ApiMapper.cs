using Domain.Enums;
using Service.Interface;

namespace Web.Mapper;

public class ApiMapper
{
    private readonly IApiService _apiService;

    public ApiMapper(IApiService apiService)
    {
        _apiService = apiService;
    }
    
    public async Task<HealthStatus> CheckApiHealth()
    {
        var result = await _apiService.CheckApiHealth();
        return result;
    }
}