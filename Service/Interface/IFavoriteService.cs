using Domain.Models.Favorites;

namespace Service.Interface;

public interface IFavoriteService
{
    Task AddPlantFavoriteAsync(string userId, Guid plantScanHistoryId);
    Task AddDiseaseFavoriteAsync(string userId, Guid diseaseScanHistoryId);
    Task RemovePlantFavoriteAsync(string userId, Guid plantScanHistoryId);
    Task RemoveDiseaseFavoriteAsync(string userId, Guid diseaseScanHistoryId);
    Task<IEnumerable<PlantScanFavorites>> GetPlantFavoritesAsync(string userId);
    Task<IEnumerable<DiseaseScanFavorites>> GetDiseaseFavoritesAsync(string userId);
}