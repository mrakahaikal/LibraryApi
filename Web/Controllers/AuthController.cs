using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dtos;
using Domain.Entities;


namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AuthService auth) : ControllerBase
    {
        private readonly AuthService _auth = auth;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            try
            {
                var result = await _auth.LoginAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        } 
    }
}