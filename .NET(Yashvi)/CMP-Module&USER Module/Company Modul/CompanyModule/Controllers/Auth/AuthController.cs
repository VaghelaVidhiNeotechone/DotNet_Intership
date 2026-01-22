using CompanyModule.Interface.Services.User;
using CompanyModule.Models.POCO.Request.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyModule.Controllers.Version1.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequest request)
        {
            var result = await _userService.Authenticate(request.email, request.password);
            return Ok(result);
        }
    }
}