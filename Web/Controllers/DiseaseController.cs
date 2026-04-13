using Domain.Enums;
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

    [HttpPost("identify")]
    public async Task<IActionResult> IdentifyAsync([FromQuery] DiseaseIDqueryRequest request, [FromForm] Organ[] organs,
        [FromForm] IFormFile[] images)
    {
        var result = await _diseaseMapper.IdentifyAsync(images, organs, request);
        return Ok(result);
    }
}