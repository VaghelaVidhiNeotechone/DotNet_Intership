using LoginWebAPI.Helpers;
using LoginWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(IConfiguration config)
        {
            _tokenService = new TokenService(config);
        }

        // LOGIN API
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (request.Username == "admin" && request.Password == "123")
            {
                string token = _tokenService.GenerateToken(request.Username);
                return Ok(new
                {
                    message = "Login Successful",
                    token = token
                });
            }

            return Unauthorized(new { message = "Invalid username or password" });
        }
    }
}
