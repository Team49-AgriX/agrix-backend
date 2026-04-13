namespace Web.Request;

public record DiseaseIDqueryRequest(
    bool IncludeRelatedImages = false,
    bool NoReject = false,
    int NumResults = 3,
    string Language = "en"
    );