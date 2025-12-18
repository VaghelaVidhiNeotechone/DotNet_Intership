using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Data;
using RepositoryPatternDemo.Models;
using RepositoryPatternDemo.Repositories;
using Xunit;

public class ProductRepositoryTests
{
    [Fact]
    public void Add_Product_Saves_To_Db()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("RepoTestDb")
            .Options;

        var context = new ApplicationDbContext(options);
        var repo = new ProductRepository(context);

        repo.Add(new Product { Name = "Test", Price = 100, Stock = 5 });
        repo.Save();

        Assert.Single(context.Products);
    }
}
