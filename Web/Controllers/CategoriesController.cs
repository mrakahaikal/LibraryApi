using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Entities;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(CategoryService service) : ControllerBase
    {
        private readonly CategoryService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cat = await _service.GetByIdAsync(id);
            return cat is null ? NotFound() : Ok(cat);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            await _service.AddAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Category category)
        {
            if (id != category.Id) return BadRequest("ID mismatch");
            await _service.UpdateAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

}