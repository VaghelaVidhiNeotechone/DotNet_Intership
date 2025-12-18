using Moq;
using RepositoryPatternDemo.Models;
using RepositoryPatternDemo.Repositories;
using RepositoryPatternDemo.Services;
using Xunit;

public class ProductServiceTests
{
    [Fact]
    public void GetAll_Returns_Data()
    {
  
        var mockRepo = new Mock<IProductRepository>();
        mockRepo
            .Setup(r => r.GetAll())
            .Returns(new List<Product>
            {
                new Product { Id = 1, Name = "Pen", Price = 10 }
            });

        var service = new ProductService(mockRepo.Object);

    
        var result = service.GetAll();

        
        Assert.Single(result);
    }
}
