using Domain.Common;

namespace Domain.Models.PlantID;

public class PlantResult : BaseEntity
{
    public double Score { get; set; }
    public Species Species { get; set; } = new();
}