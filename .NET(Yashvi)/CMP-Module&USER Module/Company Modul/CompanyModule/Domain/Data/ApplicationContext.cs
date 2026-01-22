using Microsoft.EntityFrameworkCore;
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
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Global query filters for soft delete
            modelBuilder.Entity<CompanyDetailEntity>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<CompanyAttachment>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<Country>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<Currency>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<UserRole>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<ApplicationUser>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<UserFile>()
                .HasQueryFilter(x => !x.IsDeleted);

            // Relationships
            modelBuilder.Entity<CompanyAttachment>()
                .HasOne(a => a.CompanyDetail)
                .WithMany(c => c.CompanyAttachments)
                .HasForeignKey(a => a.companyid)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.companyid)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.UserRole)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.roleid)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFile>()
                .HasOne(f => f.User)
                .WithMany(u => u.UserFiles)
                .HasForeignKey(f => f.userid)
                .OnDelete(DeleteBehavior.Restrict);

            // Table names
            modelBuilder.Entity<CompanyDetailEntity>()
                .ToTable("companydetail");

            modelBuilder.Entity<CompanyAttachment>()
                .ToTable("companyattachment");

            modelBuilder.Entity<Country>()
                .ToTable("countries");

            modelBuilder.Entity<Currency>()
                .ToTable("currencies");

            modelBuilder.Entity<UserRole>()
                .ToTable("userroles");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("users");

            modelBuilder.Entity<UserFile>()
                .ToTable("userfiles");

            base.OnModelCreating(modelBuilder);
        }
    }
}