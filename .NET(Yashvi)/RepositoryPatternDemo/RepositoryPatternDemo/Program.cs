using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Data;
using RepositoryPatternDemo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// =======================
// Add services to container
// =======================

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =======================
// Database Configuration
// =======================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// =======================
// Repository Dependency Injection
// =======================
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// =======================
// HTTP Request Pipeline
// =======================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authorization (keep even if no auth yet)
app.UseAuthorization();

app.MapControllers();

app.Run();
