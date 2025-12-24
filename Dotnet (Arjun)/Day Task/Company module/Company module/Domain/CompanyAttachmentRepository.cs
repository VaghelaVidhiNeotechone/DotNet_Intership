using Company_module.Domain.Data;
using Company_module.Interface.Repository;
using Company_module.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Company_module.Domain
{
    public class CompanyAttachmentRepository : ICompanyAttachmentRepository
    {
        private readonly ApplicationContext _context;

        public CompanyAttachmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CompanyAttachment attachment)
        {
            await _context.CompanyAttachments.AddAsync(attachment);
            await _context.SaveChangesAsync();
        }

        public async Task<CompanyAttachment> GetByIdAsync(Guid attachmentId)
        {
            return await _context.CompanyAttachments
                .FirstOrDefaultAsync(a => a.attachmentid == attachmentId && !a.IsDeleted);
        }

        public async Task<IEnumerable<CompanyAttachment>> GetAllByCompanyIdAsync(Guid companyId)
        {
            return await _context.CompanyAttachments
                .Where(a => a.companyid == companyId && !a.IsDeleted)
                .ToListAsync();
        }

        public async Task UpdateAsync(CompanyAttachment attachment)
        {
            _context.CompanyAttachments.Update(attachment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid attachmentId)
        {
            var entity = await GetByIdAsync(attachmentId);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }

}
