using EfCoreMigrationsExample.Data;
using EfCoreMigrationsExample.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BloggingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BloggingContext>();
    db.Database.Migrate(); // Applies pending migrations automatically

    // Seed initial data if DB is empty
    if (!db.Blogs.Any())
    {
        var techBlog = new Blog
        {
            Name = "Tech World",
            Posts = new List<Post>
            {
                new Post
                {
                    Title = "Introduction to EF Core",
                    Content = "Learn how to use Entity Framework Core with ASP.NET Core.",
                    Tags = new List<Tag>
                    {
                        new Tag { Name = "EF Core" },
                        new Tag { Name = "ASP.NET" }
                    }
                },
                new Post
                {
                    Title = "Understanding Relationships",
                    Content = "One-to-Many and Many-to-Many relationships in EF Core explained.",
                    Tags = new List<Tag>
                    {
                        new Tag { Name = "Database" },
                        new Tag { Name = "C#" }
                    }
                }
            }
        };

        var travelBlog = new Blog
        {
            Name = "Travel Diaries",
            Posts = new List<Post>
            {
                new Post
                {
                    Title = "Exploring Italy",
                    Content = "A guide to the best places to visit in Italy.",
                    Tags = new List<Tag>
                    {
                        new Tag { Name = "Travel" },
                        new Tag { Name = "Europe" }
                    }
                }
            }
        };

        db.Blogs.AddRange(techBlog, travelBlog);
        db.SaveChanges();
    }
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blogs}/{action=Index}/{id?}");

app.Run();
