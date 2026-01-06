using CompanyModule.Domain.Data;
using CompanyModule.Interface.Repository;
using CompanyModule.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace CompanyModule.Domain
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ApplicationContext _context;

        public CurrencyRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Currency>> GetAllAsync()
        {
            return await _context.Currencies
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<Currency?> GetByIdAsync(Guid id)
        {
            return await _context.Currencies
                .FirstOrDefaultAsync(x => x.CurrencyId == id && !x.IsDeleted);
        }

        public async Task AddAsync(Currency currency)
        {
            await _context.Currencies.AddAsync(currency);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Currency currency)
        {
            _context.Currencies.Update(currency);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Currency currency)
        {
            currency.IsDeleted = true;   
            await UpdateAsync(currency);
        }
    }
}
