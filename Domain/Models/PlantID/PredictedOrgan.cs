using Domain.Common;

namespace Domain.Models.PlantID;

public class PredictedOrgan : BaseEntity
{
    public string Image { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string Organ { get; set; } = string.Empty;
    public double Score { get; set; } = 0.0;
}