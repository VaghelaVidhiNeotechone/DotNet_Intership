using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using System.Xml;

var builder = WebApplication.CreateBuilder(args);

// Register IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Register services
builder.Services.AddSingleton<IResolver, MyResolver>();
builder.Services.AddSingleton<UserType>();
builder.Services.AddSingleton<GetAccountQuery>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ISchema, AppSchema>(services =>
    new AppSchema(new SelfActivatingServiceProvider(services)));

// Add GraphQL server
builder.Services
    .AddGraphQL(options =>
    {
        options.EnableMetrics = false;
    })
    .AddSystemTextJson();

var app = builder.Build();

app.UseHttpsRedirection();

// GraphQL endpoint → /graphql
app.UseGraphQL<ISchema>();

// Playground UI → /ui/playground
app.UseGraphQLPlayground();

app.Run();
