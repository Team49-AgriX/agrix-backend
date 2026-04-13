namespace Web.Response.Plant_Response;

public record PlantIdentificationQueryResponse(
    string Project,
    string[] Images,
    string[] Organs,
    bool IncludeRelatedImages,
    bool NoReject,
    string Type
    );