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
public class DiseaseController : ControllerBase
{
    private readonly DiseaseMapper _diseaseMapper;
    private readonly UserManager<AppUser> _userManager;

    public DiseaseController(DiseaseMapper diseaseMapper, UserManager<AppUser> userManager)
    {
        _diseaseMapper = diseaseMapper;
        _userManager = userManager;
    }

    [Authorize]
    [HttpPost("identify")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> IdentifyAsync([FromQuery] DiseaseIDqueryRequest request, [FromForm] Organ[] organs,
        [FromForm] IFormFile[] images)
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user == null) return Unauthorized();
        
        var result = await _diseaseMapper.IdentifyAsync(user.Id, images, organs, request);
        return Ok(result);
    }
}