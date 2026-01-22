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

        // ✅ CREATE
        public async Task AddAsync(CompanyAttachment attachment)
        {
            await _context.CompanyAttachments.AddAsync(attachment);
            await _context.SaveChangesAsync();
        }

        // ✅ GET BY ID (HIDE DELETED)
        public async Task<CompanyAttachment?> GetByIdAsync(Guid attachmentId)
        {
            return await _context.CompanyAttachments
                .AsNoTracking()
                .FirstOrDefaultAsync(a =>
                    a.attachmentid == attachmentId &&
                    !a.IsDeleted);
        }

        // ✅ GET ALL BY COMPANY (HIDE DELETED)
        public async Task<IEnumerable<CompanyAttachment>> GetAllByCompanyIdAsync(Guid companyId)
        {
            return await _context.CompanyAttachments
                .AsNoTracking()
                .Where(a =>
                    a.companyid == companyId &&
                    !a.IsDeleted)
                .OrderByDescending(a => a.CreatedDate)
                .ToListAsync();
        }

        // ✅ UPDATE
        public async Task UpdateAsync(CompanyAttachment attachment)
        {
            _context.CompanyAttachments.Update(attachment);
            await _context.SaveChangesAsync();
        }

        // ✅ SOFT DELETE (DO NOT REMOVE FROM DB)
        public async Task DeleteAsync(Guid attachmentId)
        {
            var entity = await _context.CompanyAttachments
                .FirstOrDefaultAsync(a =>
                    a.attachmentid == attachmentId &&
                    !a.IsDeleted);

            if (entity == null)
                return;

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
