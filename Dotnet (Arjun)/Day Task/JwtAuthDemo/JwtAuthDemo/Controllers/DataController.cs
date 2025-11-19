using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet("admin")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult GetAdminData()
        {
            return Ok("This data is for **Admin**.");
        }

        [HttpGet("user")]
        [Authorize(Policy = "UserOnly")]
        public IActionResult GetUserData()
        {
            return Ok("This data is for **User**.");
        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAllAuthenticated()
        {
            return Ok("This data can be viewed by any user with a valid token.");
        }
    }
}
