using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dtos;
using Domain.Entities;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController(LoanService service) : ControllerBase
    {
        private readonly LoanService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var loan = await _service.GetByIdAsync(id);
            return loan is null ? NotFound() : Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LoanRequestDto request)
        {
            try
            {
                await _service.CreateAsync(request);
                return Ok(new { message = "Peminjaman berhasil disimpan." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> Return(Guid id)
        {
            try
            {
                await _service.ReturnLoanAsync(id);
                return Ok(new { message = "Peminjaman berhasil dikembalikan." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}