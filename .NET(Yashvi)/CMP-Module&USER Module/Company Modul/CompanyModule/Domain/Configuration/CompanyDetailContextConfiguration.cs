using CompanyModule.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyModule.Domain.Configuration
{
    public class CompanyDetailContextConfiguration
    : IEntityTypeConfiguration<CompanyDetailEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyDetailEntity> builder)
        {
            builder.HasKey(x => x.companyid);
            builder.ToTable("companydetail");
        }
    }

}
