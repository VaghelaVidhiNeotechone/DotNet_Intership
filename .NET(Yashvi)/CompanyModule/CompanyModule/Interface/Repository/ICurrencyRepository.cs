using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface ICurrencyRepository
    {
        Task<List<Currency>> GetAllAsync();
        Task<Currency?> GetByIdAsync(Guid id);
        Task AddAsync(Currency currency);
        Task UpdateAsync(Currency currency);
        Task DeleteAsync(Currency currency);
    }
}
