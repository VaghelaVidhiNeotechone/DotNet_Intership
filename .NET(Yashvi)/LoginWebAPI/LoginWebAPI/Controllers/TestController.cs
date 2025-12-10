using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet("secured-data")]
        public IActionResult GetProtectedData()
        {
            return Ok("This is protected data. You are authorized!");
        }
    }
}
