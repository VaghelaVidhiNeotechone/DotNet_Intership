using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MyIsolatedFunctionApp
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("✅ Function1 triggered successfully!");

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteStringAsync("Hello from .NET 8 Isolated Azure Function!");

            return response;
        }
    }
}
