namespace Web.Response.Plant_Response;

public record PlantResultResponse(
    double Score,
    SpeciesResponse Species
    );