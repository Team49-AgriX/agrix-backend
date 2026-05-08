using Domain.Common;
using Domain.Models.Identity;

namespace Domain.Models.History;

public class DiseaseScanHistory : BaseEntity
{
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    public DateTime ScannedAt { get; set; } 
    public string? ResultText { get; set; } 
}