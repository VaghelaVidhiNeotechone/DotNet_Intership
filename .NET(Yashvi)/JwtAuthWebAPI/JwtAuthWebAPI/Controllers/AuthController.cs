using JwtAuthDemo.Models;
using JwtAuthDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
                return BadRequest("username and password required.");

            // Fake User Authentication (demo only)
            if (model.Username == "admin" && model.Password == "admin123")
            {
                var token = _tokenService.GenerateToken(model.Username, "Admin");
                return Ok(new { token });
            }
            else if (model.Username == "user" && model.Password == "user123")
            {
                var token = _tokenService.GenerateToken(model.Username, "User");
                return Ok(new { token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
