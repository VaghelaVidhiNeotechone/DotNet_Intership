using _3TierArchitecture.Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _3TierArchitecture.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
