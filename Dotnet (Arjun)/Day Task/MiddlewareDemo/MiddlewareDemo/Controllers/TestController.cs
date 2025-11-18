using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewareDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Middleware Running Successfully!";
        }

        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok("Hello from Middleware Example!");
        }
    }
}
