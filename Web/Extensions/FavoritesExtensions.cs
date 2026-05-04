using Domain.Models.Favorites;
using Web.Response.Favorites_Response;

namespace Web.Extensions;

public static class FavoritesExtensions
{
    public static PlantScanFavoritesResponse ToFavoritesPlantResponse(this PlantScanFavorites favorite)
    {
        return new PlantScanFavoritesResponse(
            favorite.Id,
            favorite.SavedAt,
            favorite.PlantScanId,
            favorite.UserId
        );
    }

    public static DiseaseScanFavoritesResponse ToFavoritesDiseaseResponse(this DiseaseScanFavorites favorite)
    {
        return new DiseaseScanFavoritesResponse(
            favorite.Id,
            favorite.UserId,
            favorite.SavedAt,
            favorite.PlantScanId
        );
    }
}