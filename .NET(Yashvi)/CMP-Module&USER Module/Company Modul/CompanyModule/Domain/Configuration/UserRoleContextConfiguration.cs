using CompanyModule.Models.DTO;
using CompanyModule.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Status = CompanyModule.Models.Enums.Status;

namespace CompanyModule.Domain.Configuration
{
    public class UserRoleContextConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            // Set primary key
            builder.HasKey(x => x.roleid);

            // Define foreign key for CompanyId
            builder.HasOne<CompanyDetailEntity>()
                   .WithMany()
                   .HasForeignKey(x => x.companyid)
                   .OnDelete(DeleteBehavior.Restrict);

            // Configure RoleName property
            builder.Property(x => x.rolename)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(true);

            // Configure StatusId property
            builder.Property(x => x.statusid)
                   .IsRequired();

            // Configure IsDeleted property
            builder.Property(x => x.IsDeleted)
                   .IsRequired();

            builder.HasData(new UserRole
            {
                roleid = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                rolename = "Admin",
                companyid = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                statusid = Status.Active,
                IsDeleted = false,
                createdby = Guid.Parse("2DB2BB25-7F5D-4DB2-9590-A2EDDCA08DF3"),
                createdon = DateTime.Parse("2024-11-28T06:50:16.2081438+00:00"),
                updatedby = null,
                updatedon = null
            });
        }
    }
}