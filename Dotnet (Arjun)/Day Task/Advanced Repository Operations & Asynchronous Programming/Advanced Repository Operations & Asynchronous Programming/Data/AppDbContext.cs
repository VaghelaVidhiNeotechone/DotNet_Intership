using Advanced_Repository_Operations___Asynchronous_Programming.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Advanced_Repository_Operations___Asynchronous_Programming.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
