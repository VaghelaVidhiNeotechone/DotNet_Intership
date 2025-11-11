using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = FunctionsApplication.CreateBuilder(args);

// Register ASP.NET Core integration (mandatory for .NET 8)
builder.ConfigureFunctionsWebApplication();

// Optional: enable Application Insights
// builder.Services.AddApplicationInsightsTelemetryWorkerService()
//                 .ConfigureFunctionsApplicationInsights();

// Optional: configure custom logging
builder.Services.Configure<LoggerFilterOptions>(options =>
{
    options.MinLevel = LogLevel.Information;
});

var app = builder.Build();
app.Run();
