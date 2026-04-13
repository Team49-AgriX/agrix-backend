namespace Web.Response.Plant_Response;

public record PredictedOrganResponse(
    string Image,
    string FileName,
    string Organ,
    double Score
    );