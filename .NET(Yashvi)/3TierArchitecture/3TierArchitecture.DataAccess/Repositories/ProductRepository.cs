using _3TierArchitecture.DataAccess.Data;
using _3TierArchitecture.Model.Models;

namespace _3TierArchitecture.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll() => _context.Products.ToList();

        public Product? GetById(int id) => _context.Products.Find(id);

        public void Add(Product product) => _context.Products.Add(product);

        public void Update(Product product) => _context.Products.Update(product);

        public void Delete(Product product) => _context.Products.Remove(product);

        public void Save() => _context.SaveChanges();
    }
}
