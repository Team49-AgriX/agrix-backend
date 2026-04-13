namespace Domain.Models.PlantID;

public class PlantResult
{
    public double Score { get; set; }
    public Species Species { get; set; } = new();
    public ExternalReference? Gbif { get; set; }
    public ExternalReference? Powo { get; set; }
}