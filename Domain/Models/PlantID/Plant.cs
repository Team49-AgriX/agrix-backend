using Domain.Common;

namespace Domain.Models.PlantID;

public class Plant : BaseEntity
{
    public PlantIdentificationQuery Query { get; set; } = new();
    public PredictedOrgan[] PredictedOrgans { get; set; } = [];
    public string Language { get; set; } = string.Empty;
    public string PreferedReferential { get; set; } = string.Empty;
    public string BestMatch { get; set; } = string.Empty;
    public PlantResult[] Results { get; set; } = [];
}