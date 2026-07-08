using api_db_first.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_db_first.Interfaces;

namespace api_db_first.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result is null)
                return Unauthorized(new { message = "Credenciales inválidas" });

            return Ok(result);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (result is null)
                return BadRequest(new { message = "El email ya está registrado o el rol por defecto no existe" });

            return CreatedAtAction(nameof(Register), result);
        }
    }
}
