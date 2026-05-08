using Domain.Enums;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Mapper;
using Web.Request;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlantController : ControllerBase
{
    private readonly PlantMapper _plantMapper;
    private readonly UserManager<AppUser> _userManager;

    public PlantController(PlantMapper plantMapper, UserManager<AppUser> userManager)
    {
        _plantMapper = plantMapper;
        _userManager = userManager;
    }

    [Authorize]
    [HttpPost("identify")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> IdentifyAsync([FromQuery] PlantIdentificationQueryRequest request, [FromForm] Organ[] organs,
        [FromForm] IFormFile[] images)
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user == null) return Unauthorized();
        
        var result = await _plantMapper.IdentifyAsync(user.Id, images, organs, request);
        return Ok(result);
    }
}