using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Models;
using System.Collections.Generic;


namespace RepositoryPatternDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
    }
}