using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Web.Mapper;
using Web.Request;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlantController : ControllerBase
{
    private readonly PlantMapper _plantMapper;

    public PlantController(PlantMapper plantMapper)
    {
        _plantMapper = plantMapper;
    }

    [HttpPost("identify")]
    public async Task<IActionResult> IdentifyAsync([FromQuery] PlantIdentificationQueryRequest request, [FromForm] Organ[] organs,
        [FromForm] IFormFile[] images)
    {
        var result = await _plantMapper.IdentifyAsync(images, organs, request);
        return Ok(result);
    }
}