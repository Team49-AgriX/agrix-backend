namespace Web.Response.Plant_Response;

public record PlantResponse(
    PlantIdentificationQueryResponse Query,
    PredictedOrganResponse[] PredictedOrgans,
    string Language,
    string PreferedReferential,
    string BestMatch,
    PlantResultResponse[] Results 
    );