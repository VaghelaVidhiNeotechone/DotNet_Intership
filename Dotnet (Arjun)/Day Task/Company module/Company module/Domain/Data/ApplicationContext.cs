using Microsoft.EntityFrameworkCore;
using Company_module.Domain.Configuration;
using Company_module.Models.DTO;

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

            modelBuilder.Entity<CompanyAttachment>()
                .HasOne(a => a.CompanyDetail)
                .WithMany(c => c.CompanyAttachments)
                .HasForeignKey(a => a.companyid);


            modelBuilder.Entity<CompanyDetailEntity>()
                .HasOne(cd => cd.Country)
                .WithMany(c => c.CompanyDetails)
                .HasForeignKey(cd => cd.countryid)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<CompanyDetailEntity>()
                .HasOne(cd => cd.Currency)
                .WithMany(cu => cu.CompanyDetails)
                .HasForeignKey(cd => cd.currencyid)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfiguration(
                new CompanyDetailContextConfiguration());

            modelBuilder.Entity<CompanyDetailEntity>()
                .ToTable("companydetail");

            modelBuilder.Entity<CompanyAttachment>()
                .ToTable("companyattachment");

            base.OnModelCreating(modelBuilder);
        }
    }
}
