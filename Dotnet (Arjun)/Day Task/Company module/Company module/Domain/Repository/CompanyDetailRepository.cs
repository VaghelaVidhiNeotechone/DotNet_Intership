using Company_module.Domain.Data;
using Company_module.Interface.Repository;
using Company_module.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Company_module.Domain.Repository
{
    public class CompanyDetailRepository : ICompanyDetailRepository
    {
        private readonly ApplicationContext _context;

        public CompanyDetailRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> CountryExistsAsync(Guid countryId)
        {
            return await _context.Countries
                .AnyAsync(c => c.CountryId == countryId);
        }

        public async Task<bool> CurrencyExistsAsync(Guid currencyId)
        {
            return await _context.Currencies
                .AnyAsync(c => c.CurrencyId == currencyId);
        }

        public async Task AddAsync(CompanyDetailEntity entity)
        {
            await _context.CompanyDetails.AddAsync(entity);
        }

        public async Task<List<CompanyDetailEntity>> GetAllAsync()
        {
            return await _context.CompanyDetails
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<CompanyDetailEntity?> GetByIdAsync(Guid companyId)
        {
            return await _context.CompanyDetails
                .FirstOrDefaultAsync(x => x.companyid == companyId && !x.IsDeleted);
        }

        public void Update(CompanyDetailEntity entity)
        {
            _context.CompanyDetails.Update(entity);
        }

        public void Delete(CompanyDetailEntity entity)
        {
            entity.IsDeleted = true;
            _context.CompanyDetails.Update(entity);
        }
    }

}
