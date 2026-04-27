using Domain.Common;

namespace Domain.Models.DiseaseID;

public class Disease : BaseEntity
{
    public DiseaseIDquery Query { get; set; } = new();
    public string Language { get; set; } = string.Empty;
    public virtual DiseaseResult [] Results { get; set; } = [];
}