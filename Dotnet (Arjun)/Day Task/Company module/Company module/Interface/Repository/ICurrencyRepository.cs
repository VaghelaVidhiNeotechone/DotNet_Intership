using Company_module.Models.DTO;

namespace Company_module.Interface.Repository
{
    public interface ICurrencyRepository
    {
        Task<List<Currency>> GetAllAsync();
        Task<Currency?> GetByIdAsync(Guid id);
        Task AddAsync(Currency currency);
        void Update(Currency currency);
        void Delete(Currency currency);


        Task<bool> ExistsAsync(Guid currencyid);

        Task<Guid?> GetCurrencyIdByNameAsync(string currencyName);
        Task<bool> CurrencyNameExistsAsync(string currencyName);
        Task<bool> CurrencyNameExistsExceptIdAsync(string currencyName, Guid id);


    }
}
