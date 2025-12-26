using _3TierArchitecture.Model.Models;

namespace _3TierArchitecture.DataAccess.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        void Save();
    }
}
