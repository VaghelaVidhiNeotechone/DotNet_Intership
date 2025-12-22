using Company_module.Domain.Data;
using Company_module.Interface.Repository;
using Company_module.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Company_module.Domain
{
    public class CompanyDetailRepository : ICompanyDetailRepository
    {
        private readonly ApplicationContext _context;

        public CompanyDetailRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CompanyDetailEntity entity)
        {
            await _context.CompanyDetails.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompanyDetailEntity>> GetAllAsync()
        {
            return await _context.CompanyDetails
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<CompanyDetailEntity> GetByIdAsync(Guid companyId)
        {
            return await _context.CompanyDetails
                .FirstOrDefaultAsync(x => x.companyid == companyId && !x.IsDeleted);
        }

        public async Task UpdateAsync(CompanyDetailEntity entity)
        {
            _context.CompanyDetails.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid companyId)
        {
            var data = await GetByIdAsync(companyId);
            if (data != null)
            {
                data.IsDeleted = true;
                _context.CompanyDetails.Update(data);
                await _context.SaveChangesAsync();
            }
        }



    }



}
