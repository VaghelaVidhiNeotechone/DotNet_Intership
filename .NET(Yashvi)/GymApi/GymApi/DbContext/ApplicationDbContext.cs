using Microsoft.EntityFrameworkCore;
using GymApi.Models;

namespace GymApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GymUser> GymUsers { get; set; }
    }
}
