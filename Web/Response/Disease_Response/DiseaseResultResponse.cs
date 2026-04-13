namespace Web.Response.Disease_Response;

public record DiseaseResultResponse(
    string Name,
    string Description,
    double Score
    );