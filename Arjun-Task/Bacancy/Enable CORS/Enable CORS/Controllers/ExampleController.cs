using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enable_CORS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("CORS enabled.");
        }

        //[HttpGet]
        //[DisableCors]
        //public IActionResult GetWithoutCors()
        //{
        //    return Ok("CORS is disabled for this action.");
        //}
    }

}
