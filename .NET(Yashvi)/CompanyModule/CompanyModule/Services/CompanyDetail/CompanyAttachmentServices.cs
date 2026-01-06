using CompanyModule.Domain.Data;
using CompanyModule.Interface.Repository;
using CompanyModule.Interface.Services.CompanyDetail;
using CompanyModule.Models.DTO;
using CompanyModule.Models.Enums;
using CompanyModule.Models.POCO.Request.CompanyDetail;
using Microsoft.EntityFrameworkCore;

namespace CompanyModule.Services.CompanyDetail
{
    public class CompanyAttachmentServices : ICompanyAttachmentServices
    {
        private readonly ICompanyAttachmentRepository _repo;
        private readonly ApplicationContext _context;

        public CompanyAttachmentServices(
            ICompanyAttachmentRepository repo,
            ApplicationContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task AddCompanyAttachment(CompanyAttachmentRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.companyname))
                throw new ArgumentException("Company name required");

            var company = await _context.CompanyDetails
                .FirstOrDefaultAsync(x =>
                    x.companyname.ToLower() == request.companyname.Trim().ToLower()
                    && !x.IsDeleted)
                ?? throw new Exception("Company not found");

            var exists = await _context.CompanyAttachments.AnyAsync(x =>
                x.companyid == company.companyid &&
                x.filename.ToLower() == request.filename.ToLower() &&
                !x.IsDeleted);

            if (exists)
                throw new Exception("Attachment already exists");

            var attachment = new CompanyAttachment
            {
                attachmentid = Guid.NewGuid(),
                companyid = company.companyid,
                filename = request.filename.Trim(),
                filetype = request.filetype.Trim(),
                filepath = $"uploads/{request.filename}",
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false
            };

            await _repo.AddAsync(attachment);
        }


        public async Task<CompanyAttachment> GetAttachmentById(Guid attachmentId)
        {
            return await _repo.GetByIdAsync(attachmentId);
        }

        public async Task<IEnumerable<CompanyAttachment>> GetAllAttachmentsByCompanyId(Guid companyId)
        {
            return await _repo.GetAllByCompanyIdAsync(companyId);
        }

        public async Task UpdateAttachment(CompanyAttachmentRequest request)
        {
            var existing = await _repo.GetByIdAsync(request.attachmentid);
            if (existing == null) return;

            existing.filename = request.filename;
            existing.filetype = request.filetype;
            existing.filepath = $"uploads/{request.filename}";

            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAttachment(Guid attachmentId)
        {
            await _repo.DeleteAsync(attachmentId);
        }
    }
}
