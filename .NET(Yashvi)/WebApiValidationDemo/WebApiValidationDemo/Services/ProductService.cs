using WebApiValidationDemo.Models;
using WebApiValidationDemo.Repository;

namespace WebApiValidationDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Product Add(ProductDto dto)
        {
            var newProduct = new Product
            {
                Id = _repo.GetAll().Count + 1,
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category
            };

            _repo.Add(newProduct);
            return newProduct;
        }

        public Product? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public List<Product> GetAll()
        {
            return _repo.GetAll();
        }

        public List<Product> GetByCategory(string category)
        {
            return _repo.GetByCategory(category);
        }

        public List<Product> Search(string name)
        {
            return _repo.Search(name);
        }
    }
}
