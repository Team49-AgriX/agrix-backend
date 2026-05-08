using Domain.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Mapper;

namespace Web.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly FavoritesMapper _favoritesMapper;
    private readonly UserManager<AppUser> _userManager;

    public FavoritesController(FavoritesMapper favoritesMapper, UserManager<AppUser> userManager)
    {
        _favoritesMapper = favoritesMapper;
        _userManager = userManager;
    }
    
    [HttpGet("plants")]
    public async Task<IActionResult> GetPlantScanFavoritesAsync()
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user == null) return Unauthorized();

        var result = await _favoritesMapper.GetPlantFavoritesAsync(user.Id);
        return Ok(result);
    }
    
    [HttpGet("diseases")]
    public async Task<IActionResult> GetDiseaaseScanHistoryAsync()
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user == null) return Unauthorized();

        var result = await _favoritesMapper.GetDiseaseFavoritesAsync(user.Id);
        return Ok(result);
    }

    [HttpPost("plants/{id}")]
    public async Task<IActionResult> AddPlantFavoriteAsync([FromRoute] Guid id)
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user == null) return Unauthorized();

        await _favoritesMapper.AddPlantFavoriteAsync(user.Id, id);
        return Ok();
    }
    
    [HttpPost("diseases/{id}")]
    public async Task<IActionResult> AddDiseaseFavoriteAsync([FromRoute] Guid id)
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user == null) return Unauthorized();

        await _favoritesMapper.AddDiseaseFavoriteAsync(user.Id, id);
        return Ok();
    }
    
    [HttpDelete("plants/{id}")]
    public async Task<IActionResult> RemovePlantFavoriteAsync([FromRoute] Guid id)
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user == null) return Unauthorized();

        await _favoritesMapper.RemovePlantFavoriteAsync(user.Id, id);
        return Ok();
    }
    
    [HttpDelete("diseases/{id}")]
    public async Task<IActionResult> RemoveDiseaseFavoriteAsync([FromRoute] Guid id)
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user == null) return Unauthorized();

        await _favoritesMapper.RemoveDiseaseFavoriteAsync(user.Id, id);
        return Ok();
    }
}