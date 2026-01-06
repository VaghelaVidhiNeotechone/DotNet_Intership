using Microsoft.EntityFrameworkCore;
using Company_module.Models.DTO;
using Company_module.Domain.Data.Configuration;

namespace Company_module.Domain.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<CompanyDetailEntity> CompanyDetails { get; set; }
        public DbSet<CompanyAttachment> CompanyAttachments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔹 Automatically apply ALL configuration classes
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
