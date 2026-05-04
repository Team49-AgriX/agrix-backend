using Domain.Models.History;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation;

public class HistoryService : IHistoryService
{

    private readonly IRepository<PlantScanHistory> _plantRepository;
    private readonly IRepository<DiseaseScanHistory> _diseaseRepository;

    public HistoryService(IRepository<PlantScanHistory> plantRepository, IRepository<DiseaseScanHistory> diseaseRepository)
    {
        _plantRepository = plantRepository;
        _diseaseRepository = diseaseRepository;
    }

    public async Task SavePlantScanAsync(string userId, string resultText)
    {
        var history = new PlantScanHistory
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            ResultText = resultText,
            ScannedAt = DateTime.UtcNow
        };
        
        await _plantRepository.InsertAsync(history);
    }

    public async Task SaveDiseaseScanAsync(string userId, string resultText)
    {
        var history = new DiseaseScanHistory
        {
            Id =  Guid.NewGuid(),
            UserId = userId,
            ResultText = resultText,
            ScannedAt = DateTime.UtcNow
        };
        
        await _diseaseRepository.InsertAsync(history);
    }

    public async Task<IEnumerable<PlantScanHistory>> GetPlantScanHistoryAsync(string userId)
    {
        return await _plantRepository.GetAllAsync(selector: x => x, predicate: x => x.UserId.Equals(userId)); 
    }

    public async Task<IEnumerable<DiseaseScanHistory>> GetDiseaseScanHistoryAsync(string userId)
    {
        return await _diseaseRepository.GetAllAsync(selector: x => x, predicate: x => x.UserId.Equals(userId));
    }

    public async Task<PlantScanHistory> GetPlantScanById(Guid id)
    {
        return await _plantRepository.GetAsync(selector: x => x, predicate: x => x.Id.Equals(id));
    }

    public async Task<DiseaseScanHistory> GetDiseaseScanById(Guid id)
    {
        return await _diseaseRepository.GetAsync(selector: x => x, predicate: x => x.Id.Equals(id));
    }

    public async Task<PlantScanHistory> DeletePlantScanById(Guid id)
    {
        var plant = await this.GetPlantScanById(id);

        if (plant == null)
        {
            throw new InvalidOperationException("Plant scan not found!");
        }
        
        await _plantRepository.DeleteAsync(plant);
        return plant;
    }

    public async Task<DiseaseScanHistory> DeleteDiseaseScanById(Guid id)
    {
        var disease = await this.GetDiseaseScanById(id);

        if (disease == null)
        {
            throw new InvalidOperationException("Disease scan not found!");
        }

        await _diseaseRepository.DeleteAsync(disease);
        return disease;
    }
}