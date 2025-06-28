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

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _service.GetAllAsync();
            return Ok(books);
        }

        /**
        POST: api/books
        Create new book asynchronously
        @params = Domain\Entities\Book book
        */ 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            await _service.AddAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Book book)
        {
            if (id != book.Id)
                return BadRequest("ID mismatch");

            await _service.UpdateAsync(book);
            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}