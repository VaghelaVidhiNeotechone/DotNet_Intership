using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace CorsDemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("CORS is enabled for specific origins!");
        }

        [HttpGet("nocors")]
        [DisableCors] 
        public IActionResult GetNoCors()
        {
            return Ok("CORS disabled for this specific action.");
        }
    }
}
