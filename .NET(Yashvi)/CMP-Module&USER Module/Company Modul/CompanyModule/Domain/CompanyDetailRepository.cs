using CompanyModule.Domain.Data;
using CompanyModule.Interface.Repository;
using CompanyModule.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CompanyModule.Domain
{
    public class CompanyDetailRepository : ICompanyDetailRepository
    {
        private readonly ApplicationContext _context;

        public CompanyDetailRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyDetailEntity>> GetAllAsync()
        {
            return await _context.CompanyDetails
                .Include(c => c.Country)
                .Include(c => c.Currency)
                .ToListAsync();
        }

        public async Task<CompanyDetailEntity?> GetByIdAsync(Guid id)
        {
            return await _context.CompanyDetails
                .Include(c => c.Country)
                .Include(c => c.Currency)
                .Include(c => c.CompanyAttachments)
                .FirstOrDefaultAsync(c => c.companyid == id);
        }

        public async Task<CompanyDetailEntity> CreateAsync(CompanyDetailEntity entity)
        {
            entity.companyid = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            
            _context.CompanyDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CompanyDetailEntity> UpdateAsync(CompanyDetailEntity entity)
        {
            _context.CompanyDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.CompanyDetails.FindAsync(id);
            if (entity == null) return false;

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.CompanyDetails.AnyAsync(c => c.companyid == id);
        }
    }
}