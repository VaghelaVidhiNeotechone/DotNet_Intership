using Microsoft.AspNetCore.Mvc;

namespace Logging_with_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Get method called at {time}", DateTime.UtcNow);
            return new string[] { "Sunny", "Rainy", "Cloudy" };
        }

        [HttpGet("error")]
        public IActionResult GetError()
        {
            try
            {
                throw new Exception("Sample exception");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in GetError");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
