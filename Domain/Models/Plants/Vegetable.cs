using Domain.Common;
namespace Domain.Models.Plants;

public class Vegetable : PlantBase
{
    public string EdiblePart { get; set; } = string.Empty;
    public bool IsLeafy { get; set; }
}