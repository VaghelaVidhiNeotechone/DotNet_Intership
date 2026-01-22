using CompanyModule.Interface.Repository;
using CompanyModule.Interface.Services.Currency;
using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.Currency;

namespace CompanyModule.Services
{
    public class CurrencyServices : ICurrencyServices
    {
        private readonly ICurrencyRepository _repository;

        public CurrencyServices(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Models.DTO.Currency>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Models.DTO.Currency?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Models.DTO.Currency> CreateAsync(Models.DTO.Currency currency)
        {
            return await _repository.CreateAsync(currency);
        }

        public async Task<Models.DTO.Currency> UpdateAsync(Models.DTO.Currency currency)
        {
            return await _repository.UpdateAsync(currency);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<Currency> UpdateAsync(Guid id, Currency currency)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(CurrencyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, CurrencyRequest request)
        {
            throw new NotImplementedException();
        }
    }

}