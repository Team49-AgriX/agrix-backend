using Domain.Common;
namespace Domain.Models.Plants;

public class Fruit : PlantBase
{
    public bool HasSeeds { get; set; }
    public string TasteProfile { get; set; } = string.Empty;
}