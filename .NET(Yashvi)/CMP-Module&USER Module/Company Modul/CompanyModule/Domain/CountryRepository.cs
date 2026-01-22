using CompanyModule.Domain.Data;
using CompanyModule.Interface.Repository;
using CompanyModule.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CompanyModule.Domain
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationContext _context;

        public CountryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(Guid id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.countryid == id);
        }

        public async Task<Country> CreateAsync(Country entity)
        {
            entity.countryid = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            
            _context.Countries.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Country> UpdateAsync(Country entity)
        {
            _context.Countries.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Countries.FindAsync(id);
            if (entity == null) return false;

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Countries.AnyAsync(c => c.countryid == id);
        }
    }
}