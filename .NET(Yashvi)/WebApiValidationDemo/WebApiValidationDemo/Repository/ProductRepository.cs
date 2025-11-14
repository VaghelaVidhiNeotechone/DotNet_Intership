using WebApiValidationDemo.Models;

namespace WebApiValidationDemo.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetByCategory(string category)
        {
            return _products.Where(x => x.Category.ToLower() == category.ToLower()).ToList();
        }

        public List<Product> Search(string name)
        {
            return _products.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
