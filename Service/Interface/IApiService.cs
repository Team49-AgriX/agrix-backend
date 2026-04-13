using Domain.Enums;

namespace Service.Interface;

public interface IApiService
{
    Task<HealthStatus> CheckApiHealth();
}