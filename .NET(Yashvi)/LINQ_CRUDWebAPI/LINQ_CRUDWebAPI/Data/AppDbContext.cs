using LINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace LINQ.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
    }
}
