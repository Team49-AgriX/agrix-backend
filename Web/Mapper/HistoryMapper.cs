using Service.Interface;
using Web.Extensions;
using Web.Response.History_Response;

namespace Web.Mapper;

public class HistoryMapper
{
    private readonly IHistoryService _historyService;

    public HistoryMapper(IHistoryService historyService)
    {
        _historyService = historyService;
    }
    
    public async Task<List<PlantScanResponse>> GetAllPlantScansAsync(string userId)
    {
        var result = await _historyService.GetPlantScanHistoryAsync(userId);
        return result.Select(x => x.ToPlantScanResponse()).ToList();
    }

    public async Task<List<DiseaseScanResponse>> GetAllDiseaseScansAsync(string userId)
    {
        var result = await _historyService.GetDiseaseScanHistoryAsync(userId);
        return result.Select(x => x.ToDiseaseScanResponse()).ToList();
    }

    public async Task<PlantScanResponse> GetPlantScanById(Guid id)
    {
        var result = await _historyService.GetPlantScanById(id);
        return result.ToPlantScanResponse();
    }

    public async Task<DiseaseScanResponse> GetDiseaseScanById(Guid id)
    {
        var result = await _historyService.GetDiseaseScanById(id);
        return result.ToDiseaseScanResponse();
    }
    
    public async Task<PlantScanResponse> DeletePlantScanById(Guid id)
    {
        var result = await _historyService.DeletePlantScanById(id);
        return result.ToPlantScanResponse();
    }

    public async Task<DiseaseScanResponse> DeleteDiseaseScanById(Guid id)
    {
        var result = await _historyService.DeleteDiseaseScanById(id);
        return result.ToDiseaseScanResponse();
    }
}