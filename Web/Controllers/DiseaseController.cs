using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Mapper;
using Web.Request;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiseaseController : ControllerBase
{
    private readonly DiseaseMapper _diseaseMapper;

    public DiseaseController(DiseaseMapper diseaseMapper)
    {
        _diseaseMapper = diseaseMapper;
    }

    [Authorize]
    [HttpPost("identify")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> IdentifyAsync([FromQuery] DiseaseIDqueryRequest request, [FromForm] Organ[] organs,
        [FromForm] IFormFile[] images)
    {
        var result = await _diseaseMapper.IdentifyAsync(images, organs, request);
        return Ok(result);
    }
}