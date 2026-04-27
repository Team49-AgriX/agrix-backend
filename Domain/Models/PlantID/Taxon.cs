using Domain.Common;

namespace Domain.Models.PlantID;

public class Taxon : BaseEntity
{
    public string ScientificNameWithoutAuthor { get; set; } = string.Empty;
    public string ScientificNameAuthorship { get; set; } = string.Empty;
    public string ScientificName { get; set; } = string.Empty;
}