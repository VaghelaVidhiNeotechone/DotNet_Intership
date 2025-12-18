using RepositoryPatternDemo.Models;
using RepositoryPatternDemo.Repositories;

namespace RepositoryPatternDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAll()
            => _repository.GetAll();

        public Product GetById(int id)
            => _repository.GetById(id);

        public void Add(Product product)
        {
            _repository.Add(product);
            _repository.Save();
        }

        public void Update(Product product)
        {
            _repository.Update(product);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
