using Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Mapper;
using Web.Request;

namespace Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class FruitController : ControllerBase
    {
        private readonly FruitMapper _fruitMapper;
        public FruitController(FruitMapper fruitMapper)
        {
            _fruitMapper = fruitMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _fruitMapper.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _fruitMapper.GetByIdAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FruitRequest request)
        {
            try
            {
                var result = await _fruitMapper.CreateAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] FruitRequest request)
        {
            try
            {
                var result = await _fruitMapper.UpdateAsync(id, request);
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
                var result = await _fruitMapper.DeleteAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
