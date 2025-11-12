using Microsoft.EntityFrameworkCore;
using ProductsApiDemo.Models;

namespace ProductsApiDemo.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public ApiDbContext() { }

        public DbSet<Product> Products => Set<Product>();
    }
}
