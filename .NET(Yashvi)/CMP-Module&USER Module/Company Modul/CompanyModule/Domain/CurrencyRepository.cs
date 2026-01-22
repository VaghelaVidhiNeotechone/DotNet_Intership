using CompanyModule.Domain.Data;
using CompanyModule.Interface.Repository;
using CompanyModule.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CompanyModule.Domain
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ApplicationContext _context;

        public CurrencyRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency?> GetByIdAsync(Guid id)
        {
            return await _context.Currencies.FirstOrDefaultAsync(c => c.currencyid == id);
        }

        public async Task<Currency> CreateAsync(Currency entity)
        {
            entity.currencyid = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            
            _context.Currencies.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Currency> UpdateAsync(Currency entity)
        {
            _context.Currencies.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Currencies.FindAsync(id);
            if (entity == null) return false;

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Currencies.AnyAsync(c => c.currencyid == id);
        }
    }
}