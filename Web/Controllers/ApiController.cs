using Microsoft.AspNetCore.Mvc;
using Web.Mapper;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private readonly ApiMapper _apiMapper;

    public ApiController(ApiMapper apiMapper)
    {
        _apiMapper = apiMapper;
    }

    [HttpGet("health")]
    public async Task<IActionResult> GetHealth()
    {
        var status = await _apiMapper.CheckApiHealth();
        return Ok(status);
    }
}