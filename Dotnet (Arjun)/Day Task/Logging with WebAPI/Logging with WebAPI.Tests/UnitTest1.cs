using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Logging_with_WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Logging_with_WebAPI.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void Get_ReturnsValues()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(mockLogger.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Contains("Sunny", result);
        }

        [Fact]
        public void GetError_Returns500()
        {
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(mockLogger.Object);

            var result = controller.GetError() as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }
    }
}
