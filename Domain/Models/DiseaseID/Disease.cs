using Domain.Common;
using Domain.Dto;

namespace Domain.Models.DiseaseID;

public class Disease : BaseEntity
{
    public DiseaseIdDto Query { get; set; } = new();
    public string Language { get; set; } = string.Empty;
    public DiseaseResult [] Results { get; set; } = [];
}