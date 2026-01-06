using CompanyModule.Domain.Data;
using CompanyModule.Interface.Repository;
using CompanyModule.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace CompanyModule.Domain
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationContext _context;

        public CountryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(Guid id)
        {
            return await _context.Countries
                .FirstOrDefaultAsync(x => x.CountryId == id && !x.IsDeleted);
        }

        public async Task AddAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Country country)
        {
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Country country)
        {
            country.IsDeleted = true;   
            await UpdateAsync(country);
        }
    }
}
