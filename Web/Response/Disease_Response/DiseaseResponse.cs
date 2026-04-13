namespace Web.Response.Disease_Response;

public record DiseaseResponse(
    DiseaseIDqueryResponse Query,
    string Language,
    DiseaseResultResponse [] Results
    );