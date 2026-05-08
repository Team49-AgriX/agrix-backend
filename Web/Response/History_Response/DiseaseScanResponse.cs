namespace Web.Response.History_Response;

public record DiseaseScanResponse(
    Guid Id,
    string UserId,
    DateTime ScannedAt,
    string? ResultText
    );