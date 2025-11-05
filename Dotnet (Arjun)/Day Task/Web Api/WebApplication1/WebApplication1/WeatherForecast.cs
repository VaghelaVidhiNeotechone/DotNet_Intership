namespace WebApplication1
{
    public class WeatherForecast
    {
        public int Id { get; set; }  // For CRUD, we need an ID
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
