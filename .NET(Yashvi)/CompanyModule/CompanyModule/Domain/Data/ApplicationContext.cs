using Microsoft.EntityFrameworkCore;
using CompanyModule.Domain.Configuration;
using CompanyModule.Models.DTO;

namespace CompanyModule.Domain.Data
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
            // ==============================
            // 🔹 GLOBAL SOFT DELETE FILTERS
            // ==============================
            modelBuilder.Entity<CompanyDetailEntity>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<CompanyAttachment>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<Country>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<Currency>()
                .HasQueryFilter(x => !x.IsDeleted);

            // ==============================
            // 🔹 RELATIONSHIPS
            // ==============================

            // CompanyDetail ↔ CompanyAttachment (1-M)
            modelBuilder.Entity<CompanyAttachment>()
                .HasOne(a => a.CompanyDetail)
                .WithMany(c => c.CompanyAttachments)
                .HasForeignKey(a => a.companyid)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyDetail ↔ Country (M-1)
            modelBuilder.Entity<CompanyDetailEntity>()
                .HasOne(cd => cd.Country)
                .WithMany(c => c.CompanyDetails)
                .HasForeignKey(cd => cd.countryid)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyDetail ↔ Currency (M-1)
            modelBuilder.Entity<CompanyDetailEntity>()
                .HasOne(cd => cd.Currency)
                .WithMany(cu => cu.CompanyDetails)
                .HasForeignKey(cd => cd.currencyid)
                .OnDelete(DeleteBehavior.Restrict);

            // ==============================
            // 🔹 ENTITY CONFIGURATIONS
            // ==============================
            modelBuilder.ApplyConfiguration(
                new CompanyDetailContextConfiguration());

            // ==============================
            // 🔹 TABLE NAMES
            // ==============================
            modelBuilder.Entity<CompanyDetailEntity>()
                .ToTable("companydetail");

            modelBuilder.Entity<CompanyAttachment>()
                .ToTable("companyattachment");

            modelBuilder.Entity<Country>()
                .ToTable("countries");

            modelBuilder.Entity<Currency>()
                .ToTable("currencies");

            base.OnModelCreating(modelBuilder);
        }
    }
}
