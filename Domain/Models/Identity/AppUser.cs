using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Identity;

public class AppUser : IdentityUser
{
    public string? FirebaseUserId { get; set; }
    public string? DisplayName { get; set; }
}