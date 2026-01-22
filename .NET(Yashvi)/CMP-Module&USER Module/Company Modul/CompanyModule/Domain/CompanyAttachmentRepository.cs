using CompanyModule.Domain.Data;
using CompanyModule.Interface.Repository;
using CompanyModule.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CompanyModule.Domain
{
    public class CompanyAttachmentRepository : ICompanyAttachmentRepository
    {
        private readonly ApplicationContext _context;

        public CompanyAttachmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyAttachment>> GetAllAsync()
        {
            return await _context.CompanyAttachments
                .Include(a => a.CompanyDetail)
                .ToListAsync();
        }

        public async Task<CompanyAttachment?> GetByIdAsync(Guid id)
        {
            return await _context.CompanyAttachments
                .Include(a => a.CompanyDetail)
                .FirstOrDefaultAsync(a => a.attachmentid == id);
        }

        public async Task<IEnumerable<CompanyAttachment>> GetByCompanyIdAsync(Guid companyId)
        {
            return await _context.CompanyAttachments
                .Where(a => a.companyid == companyId)
                .ToListAsync();
        }

        public async Task<CompanyAttachment> CreateAsync(CompanyAttachment entity)
        {
            entity.attachmentid = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            
            _context.CompanyAttachments.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CompanyAttachment> UpdateAsync(CompanyAttachment entity)
        {
            _context.CompanyAttachments.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.CompanyAttachments.FindAsync(id);
            if (entity == null) return false;

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.CompanyAttachments.AnyAsync(a => a.attachmentid == id);
        }
    }
}