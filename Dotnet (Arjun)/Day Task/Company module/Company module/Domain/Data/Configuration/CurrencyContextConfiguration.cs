using Company_module.Models.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Company_module.Domain.Data.Configuration
{
    public class CurrencyContextConfiguration
        : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(x => x.CurrencyId);

            builder.ToTable("currency");

            builder.Property(x => x.CurrencyName)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
