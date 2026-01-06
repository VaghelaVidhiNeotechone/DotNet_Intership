using Company_module.Models.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Company_module.Domain.Data.Configuration
{
    public class CountryContextConfiguration
        : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.CountryId);

            builder.ToTable("country");

            builder.Property(x => x.CountryName)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
