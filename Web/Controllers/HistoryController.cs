using Domain.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Mapper;

namespace Web.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class HistoryController : ControllerBase
{
    private readonly HistoryMapper _historyMapper;
    private readonly UserManager<AppUser> _userManager;

    public HistoryController(HistoryMapper historyMapper, UserManager<AppUser> userManager)
    {
        _historyMapper = historyMapper;
        _userManager = userManager;
    }

    [HttpGet("plants")]
    public async Task<IActionResult> GetPlantScanHistoryAsync()
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user == null) return Unauthorized();

        var result = await _historyMapper.GetAllPlantScansAsync(user.Id);
        return Ok(result);
    }
    
    [HttpGet("diseases")]
    public async Task<IActionResult> GetDiseaaseScanHistoryAsync()
    {
        var firebaseUid = User.FindFirst("user_id")?.Value;
        if (string.IsNullOrEmpty(firebaseUid)) return Unauthorized();

        var user = await _userManager.FindByLoginAsync("Firebase", firebaseUid);
        if (user == null) return Unauthorized();

        var result = await _historyMapper.GetAllDiseaseScansAsync(user.Id);
        return Ok(result);
    }

    [HttpGet("plants/{id}")]
    public async Task<IActionResult> GetPlantScanByIdAsync([FromRoute] Guid id)
    {
        var result = await _historyMapper.GetPlantScanById(id);
        return Ok(result);
    }
    
    [HttpGet("diseases/{id}")]
    public async Task<IActionResult> GetDiseaseScanByIdAsync([FromRoute] Guid id)
    {
        var result = await _historyMapper.GetDiseaseScanById(id);
        return Ok(result);
    }

    [HttpDelete("plants/{id}")]
    public async Task<IActionResult> DeletePlantScanAsync([FromRoute] Guid id)
    {
        var result = await _historyMapper.DeletePlantScanById(id);
        return Ok(result);
    }
    
    [HttpDelete("diseases/{id}")]
    public async Task<IActionResult> DeleteDiseaseScanAsync([FromRoute] Guid id)
    {
        var result = await _historyMapper.DeleteDiseaseScanById(id);
        return Ok(result);
    }
}