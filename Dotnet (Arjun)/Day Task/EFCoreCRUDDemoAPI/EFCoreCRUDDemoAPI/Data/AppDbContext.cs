using EFCoreCRUDDemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCRUDDemoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }
    }
}
