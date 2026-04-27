using Domain.Common;

namespace Domain.Models.DiseaseID;

public class DiseaseResult : BaseEntity
{
    public string? Name { get; set; } 
    public string? Description { get; set; }
    public double Score { get; set; }
}