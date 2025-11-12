using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // In-memory data store
        private static readonly List<WeatherForecast> _forecasts = new List<WeatherForecast>
        {
            new WeatherForecast { Id = 1, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), TemperatureC = 25, Summary = "Warm" },
            new WeatherForecast { Id = 2, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), TemperatureC = 18, Summary = "Cool" }
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // ✅ READ all
        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> GetAll()
        {
            return Ok(_forecasts);
        }

        // ✅ READ one by ID
        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> GetById(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast == null)
                return NotFound();

            return Ok(forecast);
        }

        // ✅ CREATE new
        [HttpPost]
        public ActionResult<WeatherForecast> Create(WeatherForecast forecast)
        {
            forecast.Id = _forecasts.Any() ? _forecasts.Max(f => f.Id) + 1 : 1;
            _forecasts.Add(forecast);
            return CreatedAtAction(nameof(GetById), new { id = forecast.Id }, forecast);
        }

        // ✅ UPDATE existing
        [HttpPut("{id}")]
        public IActionResult Update(int id, WeatherForecast updatedForecast)
        {
            var existing = _forecasts.FirstOrDefault(f => f.Id == id);
            if (existing == null)
                return NotFound();

            existing.Date = updatedForecast.Date;
            existing.TemperatureC = updatedForecast.TemperatureC;
            existing.Summary = updatedForecast.Summary;

            return NoContent(); // 204
        }

        // ✅ DELETE by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast == null)
                return NotFound();

            _forecasts.Remove(forecast);
            return NoContent();
        }
    }
}
