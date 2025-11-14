using WebApiValidationDemo.Models;

namespace WebApiValidationDemo.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        List<Product> GetByCategory(string category);
        List<Product> Search(string name);
    }
}
