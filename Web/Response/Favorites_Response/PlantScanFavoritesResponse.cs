namespace Web.Response.Favorites_Response;

public record PlantScanFavoritesResponse(
    Guid Id,
    DateTime SavedAt,
    Guid PlantScanId,
    string UserId
    );