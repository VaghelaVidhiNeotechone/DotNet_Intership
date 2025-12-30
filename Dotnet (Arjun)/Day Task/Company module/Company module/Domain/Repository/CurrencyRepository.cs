using Company_module.Domain.Data;
using Company_module.Interface.Repository;
using Company_module.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace Company_module.Domain.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ApplicationContext _context;

        public CurrencyRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> CurrencyNameExistsExceptIdAsync(string currencyName, Guid id)
        {
            return await _context.Currencies
                .AnyAsync(x =>
                    x.CurrencyName == currencyName &&
                    x.CurrencyId != id &&
                    !x.IsDeleted);
        }


        public async Task<bool> CurrencyNameExistsAsync(string currencyName)
        {
            return await _context.Currencies
                .AnyAsync(x =>
                    x.CurrencyName.ToLower() == currencyName.ToLower()
                    && !x.IsDeleted);
        }


        public async Task<Guid?> GetCurrencyIdByNameAsync(string currencyName)
        {
            return await _context.Currencies
                .Where(x => x.CurrencyName == currencyName && !x.IsDeleted)
                .Select(x => (Guid?)x.CurrencyId)
                .FirstOrDefaultAsync();
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

        public async Task<bool> ExistsAsync(Guid currencyid)
        {
            return await _context.Currencies
                .AnyAsync(x => x.CurrencyId == currencyid && !x.IsDeleted);
        }

        public async Task AddAsync(Currency currency)
        {
            await _context.Currencies.AddAsync(currency);
        }

        public void Update(Currency currency)
        {
            _context.Currencies.Update(currency);
        }

        public void Delete(Currency currency)
        {
            currency.IsDeleted = true;
            _context.Currencies.Update(currency);
        }
    }

}
