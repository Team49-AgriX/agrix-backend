using Domain.Models.Favorites;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation;

public class FavoriteService : IFavoriteService
{
    private readonly IRepository<PlantScanFavorites> _plantScanFavorites;
    private readonly IRepository<DiseaseScanFavorites> _disaseScanFavorites;
    private readonly IHistoryService _historyService;

    public FavoriteService(IRepository<PlantScanFavorites> plantScanFavorites, IRepository<DiseaseScanFavorites> disaseScanFavorites, IHistoryService historyService)
    {
        _plantScanFavorites = plantScanFavorites;
        _disaseScanFavorites = disaseScanFavorites;
        _historyService = historyService;
    }

    public async Task AddPlantFavoriteAsync(string userId, Guid plantScanHistoryId)
    {
        var scan = await _historyService.GetPlantScanById(plantScanHistoryId);
        if (scan == null) throw new InvalidOperationException("Plant scan not found");

        var existing = await _plantScanFavorites.GetAllAsync(selector: x => x,
            predicate: x => x.UserId == userId && x.PlantScanId == plantScanHistoryId);
        
        if (existing.Any()) return;

        var favorite = new PlantScanFavorites
        {
            Id = Guid.NewGuid(),
            PlantScanId = plantScanHistoryId,
            SavedAt = DateTime.UtcNow,
            UserId = userId
        };
        
        await _plantScanFavorites.InsertAsync(favorite);
    }

    public async Task AddDiseaseFavoriteAsync(string userId, Guid diseaseScanHistoryId)
    {
        var scan = await _historyService.GetDiseaseScanById(diseaseScanHistoryId);
        if (scan == null) throw new InvalidOperationException("Disease scan not found");

        var existing = await _disaseScanFavorites.GetAllAsync(selector: x => x,
            predicate: x => x.UserId == userId && x.PlantScanId == diseaseScanHistoryId);
        
        if (existing.Any()) return;

        var favorite = new DiseaseScanFavorites
        {
            Id = Guid.NewGuid(),
            PlantScanId = diseaseScanHistoryId,
            SavedAt = DateTime.UtcNow,
            UserId = userId
        };
        
        await _disaseScanFavorites.InsertAsync(favorite);
    }

    public async Task RemovePlantFavoriteAsync(string userId, Guid plantScanHistoryId)
    {
        var existing = await _plantScanFavorites.GetAllAsync(selector: x => x,
            predicate: x => x.UserId == userId && x.PlantScanId == plantScanHistoryId);

        var favorite = existing.FirstOrDefault();
        if (favorite == null) return;
        
        await _plantScanFavorites.DeleteAsync(favorite);
    }

    public async Task RemoveDiseaseFavoriteAsync(string userId, Guid diseaseScanHistoryId)
    {
        var existing = await _disaseScanFavorites.GetAllAsync(selector: x => x,
            predicate: x => x.UserId == userId && x.PlantScanId == diseaseScanHistoryId);
        
        var favorite = existing.FirstOrDefault();
        if (favorite == null) return;

        await _disaseScanFavorites.DeleteAsync(favorite);
    }

    public async Task<IEnumerable<PlantScanFavorites>> GetPlantFavoritesAsync(string userId)
    {
        return await _plantScanFavorites.GetAllAsync(selector: x => x, predicate: x => x.UserId == userId);
    }

    public async Task<IEnumerable<DiseaseScanFavorites>> GetDiseaseFavoritesAsync(string userId)
    {
        return await _disaseScanFavorites.GetAllAsync(selector: x => x, predicate: x => x.UserId == userId);
    }
}