using Domain.Models.DiseaseID;
using Web.Response.Disease_Response;

namespace Web.Extensions;

public static class DiseaseExtensions
{
    public static DiseaseIDqueryResponse ToDiseaseIDqueryResponse(this DiseaseIDquery dto)
    {
        return new DiseaseIDqueryResponse(
            dto.Images,
            dto.Organs,
            dto.IncludeRelatedImages,
            dto.NoReject
        );
    }

    public static DiseaseResultResponse ToDiseaseResultResponse(this DiseaseResult diseaseResult)
    {
        return new DiseaseResultResponse(
            diseaseResult.Name ?? "",
            diseaseResult.Description ?? "",
            diseaseResult.Score
        );
    }

    public static DiseaseResponse ToDiseaseResponse(this Disease disease)
    {
        return new DiseaseResponse(
            disease.Query.ToDiseaseIDqueryResponse(),
            disease.Language,
            disease.Results.Select(x => x.ToDiseaseResultResponse()).ToArray()
        );
    }
}