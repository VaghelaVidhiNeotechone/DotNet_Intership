using WebApiValidationDemo.Models;

namespace WebApiValidationDemo.Services
{
    public interface IProductService
    {
        Product Add(ProductDto dto);
        Product? GetById(int id);
        List<Product> GetAll();
        List<Product> GetByCategory(string category);
        List<Product> Search(string name);
    }
}
