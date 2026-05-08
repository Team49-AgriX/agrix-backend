using Domain.Models.History;

namespace Service.Interface;

public interface IHistoryService
{
    Task SavePlantScanAsync(string userId, string resultText);
    Task SaveDiseaseScanAsync(string userId, string resultText);
    Task<IEnumerable<PlantScanHistory>> GetPlantScanHistoryAsync(string userId);
    Task<IEnumerable<DiseaseScanHistory>> GetDiseaseScanHistoryAsync(string userId);
    Task<PlantScanHistory> GetPlantScanById(Guid id);
    Task<DiseaseScanHistory> GetDiseaseScanById(Guid id);
    Task<PlantScanHistory> DeletePlantScanById(Guid id);
    Task<DiseaseScanHistory> DeleteDiseaseScanById(Guid id);
}