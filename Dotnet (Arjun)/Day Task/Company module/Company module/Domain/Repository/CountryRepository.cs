using Company_module.Domain.Data;
using Company_module.Interface.Repository;
using Company_module.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace Company_module.Domain.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationContext _context;

        public CountryRepository(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<bool> CountryNameExistsExceptIdAsync(string countryName, Guid id)
        {
            return await _context.Countries
                .AnyAsync(x =>
                    x.CountryName == countryName &&
                    x.CountryId != id && 
                    !x.IsDeleted);
        }


        public async Task<bool> CountryNameExistsAsync(string countryName)
        {
            return await _context.Countries
                .AnyAsync(x =>
                    x.CountryName.ToLower() == countryName.ToLower()
                    && !x.IsDeleted);
        }


        public async Task<Guid?> GetCountryIdByNameAsync(string countryName)
        {
            return await _context.Countries
                .Where(x => x.CountryName == countryName && !x.IsDeleted)
                .Select(x => (Guid?)x.CountryId)
                .FirstOrDefaultAsync();
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

        public async Task<bool> ExistsAsync(Guid countryid)
        {
            return await _context.Countries
                .AnyAsync(x => x.CountryId == countryid && !x.IsDeleted);
        }

        public async Task AddAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
        }

        public void Update(Country country)
        {
            _context.Countries.Update(country);
        }

        public void Delete(Country country)
        {
            country.IsDeleted = true;
            Update(country);
        }
    }

}
