var builder = WebApplication.CreateBuilder(args);


// 1. SERVICES (ConfigureServices)


builder.Services.AddControllers();

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder.WithOrigins("https://example.com")   // your allowed origin
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


var app = builder.Build();


// 2. MIDDLEWARE (Configure)


// Developer exception page
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

// Apply the CORS policy
app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
