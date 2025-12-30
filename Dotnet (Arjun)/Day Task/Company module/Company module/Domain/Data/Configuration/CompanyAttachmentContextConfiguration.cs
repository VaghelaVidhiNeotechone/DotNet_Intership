using Company_module.Models.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Company_module.Domain.Data.Configuration
{
    public class CompanyAttachmentContextConfiguration
        : IEntityTypeConfiguration<CompanyAttachment>
    {
        public void Configure(EntityTypeBuilder<CompanyAttachment> builder)
        {
            // Primary Key
            builder.HasKey(x => x.attachmentid);

            // Table Name
            builder.ToTable("companyattachment");

            // Foreign Key mapping
            builder.HasOne(x => x.CompanyDetail)
                   .WithMany(x => x.CompanyAttachments)
                   .HasForeignKey(x => x.companyid);
        }
    }
}
