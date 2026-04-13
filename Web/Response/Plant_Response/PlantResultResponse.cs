namespace Web.Response.Plant_Response;

public record PlantResultResponse(
    double Score,
    SpeciesResponse Species,
    ExternalReferenceResponse? Gbif,
    ExternalReferenceResponse? Powo
    );