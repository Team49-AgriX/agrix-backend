using Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Mapper;
using Web.Request;

namespace Web.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class VegetableController : ControllerBase
    {
        private readonly VegetableMapper _vegetableMapper;

        public VegetableController(VegetableMapper vegetableMapper)
        {
            _vegetableMapper = vegetableMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _vegetableMapper.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _vegetableMapper.GetByIdAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VegetableRequest request)
        {
            try
            {
                var result = await _vegetableMapper.CreateAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] VegetableRequest request)
        {
            try
            {
                var result = await _vegetableMapper.UpdateAsync(id, request);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _vegetableMapper.DeleteAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
