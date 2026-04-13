namespace Domain.Models.PlantID;

public class Species
{
    public string ScientificNameWithoutAuthor { get; set; } = string.Empty;
    public string ScientificNameAuthorship { get; set; } = string.Empty;
    public Taxon Genus { get; set; } = new();
    public Taxon Family { get; set; } = new();
    public string[] CommonNames { get; set; } = [];
    public string ScientificName { get; set; } = string.Empty;
}