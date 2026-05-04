namespace Web.Response.History_Response;

public record PlantScanResponse(
    Guid Id,
    string UserId,
    DateTime ScannedAt,
    string? ResultText
    );