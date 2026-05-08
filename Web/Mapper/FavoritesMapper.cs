using Service.Interface;
using Web.Extensions;
using Web.Response.Favorites_Response;

namespace Web.Mapper;

public class FavoritesMapper
{
    private readonly IFavoriteService _favoriteService;

    public FavoritesMapper(IFavoriteService favoriteService)
    {
        _favoriteService = favoriteService;
    }

    public async Task AddPlantFavoriteAsync(string userId, Guid plantScanHistoryId)
    {
        await _favoriteService.AddPlantFavoriteAsync(userId, plantScanHistoryId);
    }

    public async Task AddDiseaseFavoriteAsync(string userId, Guid diseaseScanHistoryId)
    {
        await _favoriteService.AddDiseaseFavoriteAsync(userId, diseaseScanHistoryId);
    }

    public async Task RemovePlantFavoriteAsync(string userId, Guid plantScanHistoryId)
    {
        await _favoriteService.RemovePlantFavoriteAsync(userId, plantScanHistoryId);
    }

    public async Task RemoveDiseaseFavoriteAsync(string userId, Guid diseaseScanHistoryId)
    {
        await _favoriteService.RemoveDiseaseFavoriteAsync(userId, diseaseScanHistoryId);
    }

    public async Task<IEnumerable<PlantScanFavoritesResponse>> GetPlantFavoritesAsync(string userId)
    {
        var result = await _favoriteService.GetPlantFavoritesAsync(userId);
        return result.Select(x => x.ToFavoritesPlantResponse()).ToList();
    }

    public async Task<IEnumerable<DiseaseScanFavoritesResponse>> GetDiseaseFavoritesAsync(string userId)
    {
        var result = await _favoriteService.GetDiseaseFavoritesAsync(userId);
        return result.Select(x => x.ToFavoritesDiseaseResponse()).ToList();
    }
}