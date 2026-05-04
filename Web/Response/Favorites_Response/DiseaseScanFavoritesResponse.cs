namespace Web.Response.Favorites_Response;

public record DiseaseScanFavoritesResponse(
    Guid Id,
    string UserId,
    DateTime SavedAt,
    Guid PlantScanId
    );