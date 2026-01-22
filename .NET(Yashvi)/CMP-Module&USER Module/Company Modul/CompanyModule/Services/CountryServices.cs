using CompanyModule.Interface.Repository;
using CompanyModule.Interface.Services.Country;
using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.Country;

namespace CompanyModule.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly ICountryRepository _repository;

        public CountryServices(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Models.DTO.Country>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Models.DTO.Country?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Models.DTO.Country> CreateAsync(Models.DTO.Country country)
        {
            return await _repository.CreateAsync(country);
        }

        public async Task<Models.DTO.Country> UpdateAsync(Models.DTO.Country country)
        {
            return await _repository.UpdateAsync(country);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<Country> UpdateAsync(Guid id, Country country)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, CountryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(CountryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}