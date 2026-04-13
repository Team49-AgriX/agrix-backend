namespace Web.Response.Disease_Response;

public record DiseaseIDqueryResponse(
    string[] Images,
    string[] Organs,
    bool IncludeRelatedImages,
    bool NoReject
    );