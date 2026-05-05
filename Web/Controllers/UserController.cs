using Domain.Dto;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Web.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IProfileService _profileService;

    public UserController(UserManager<AppUser> userManager, IProfileService profileService)
    {
        _userManager = userManager;
        _profileService = profileService;
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
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var existingProfile = await _profileService.GetProfileAsync(firebaseUid);
        if (existingProfile != null) return Conflict("Profile already exists.");

        await _profileService.CreateProfileAsync(firebaseUid, request.DisplayName, request.Phone);

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user != null)
        {
            user.DisplayName = request.DisplayName;
            await _userManager.UpdateAsync(user);
        }

        return Ok();
    }
    
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfileAsync()
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var profile = await _profileService.GetProfileAsync(firebaseUid);
        if (profile == null) return NotFound();

        return Ok(profile);
    }

    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfileAsync([FromBody] RegisterRequest request)
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var existingProfile = await _profileService.GetProfileAsync(firebaseUid);
        if (existingProfile == null) return NotFound("Profile not found.");

        await _profileService.UpdateProfileAsync(firebaseUid, request.DisplayName, request.Phone);

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user != null)
        {
            user.DisplayName = request.DisplayName;
            await _userManager.UpdateAsync(user);
        }

        return Ok();
    }
    
    [HttpPut("fcm-token")]
    public async Task<IActionResult> UpdateFcmTokenAsync([FromBody] UpdateFcmTokenRequest request)
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        await _profileService.UpdateFcmTokenAsync(firebaseUid, request.FcmToken);
        return Ok();
    }
}