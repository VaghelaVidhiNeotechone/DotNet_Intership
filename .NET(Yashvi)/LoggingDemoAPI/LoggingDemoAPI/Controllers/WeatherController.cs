
using Microsoft.AspNetCore.Mvc;

namespace LoggingDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet("today")]
        public IActionResult GetWeather()
        {
            _logger.LogInformation("Weather API called at {time}", DateTime.Now);

            var data = new
            {
                Temperature = "30°C",
                City = "Mumbai",
                Date = DateTime.Now
            };

            _logger.LogInformation("Weather data returned successfully");

            return Ok(data);
        }
    }
}
