using Domain.Common;
using Domain.Models.History;
using Domain.Models.Identity;

namespace Domain.Models.Favorites;

public class DiseaseScanFavorites : BaseEntity
{
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    public DateTime SavedAt { get; set; }
    public Guid PlantScanId { get; set; }
    public PlantScanHistory? PlantScanHistory { get; set; }
}