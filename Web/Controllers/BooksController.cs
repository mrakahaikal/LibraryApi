namespace Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Application.Services;
    using Domain.Entities;

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController(BookService service) : ControllerBase
    {
        private readonly BookService _service = service;

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _service.GetByIdAsync(id);
            return book is null ? NotFound() : Ok(book);
        }
    }
}