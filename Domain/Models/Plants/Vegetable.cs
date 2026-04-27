using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Plants;

public class Vegetable
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}