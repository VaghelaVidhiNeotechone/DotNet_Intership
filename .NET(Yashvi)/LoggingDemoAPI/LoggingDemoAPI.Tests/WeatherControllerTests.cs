using LoggingDemoAPI.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LoggingDemoAPI.Tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public void GetWeather_ReturnsOkResult()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<WeatherController>>();
            var controller = new WeatherController(mockLogger.Object);

            // Act
            var result = controller.GetWeather();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
