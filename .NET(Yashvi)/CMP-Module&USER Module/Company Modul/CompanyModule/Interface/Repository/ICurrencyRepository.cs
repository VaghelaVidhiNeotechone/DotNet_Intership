using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAllAsync();
        Task<Currency?> GetByIdAsync(Guid id);
        Task<Currency> CreateAsync(Currency entity);
        Task<Currency> UpdateAsync(Currency entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}