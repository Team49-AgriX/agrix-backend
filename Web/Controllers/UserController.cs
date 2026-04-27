using Domain.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;

    public UserController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        var uid = User.FindFirst("user_id")?.Value;

        if (string.IsNullOrEmpty(uid))
        {
            return Unauthorized();
        }

        var user = await _userManager.FindByLoginAsync("Firebase", uid);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            user.Id,
            user.Email,
            user.DisplayName,
            user.FirebaseUserId
        });
    }
}