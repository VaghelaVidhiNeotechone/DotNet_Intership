using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.Currency;

namespace CompanyModule.Interface.Services.Currency
{
    public interface ICurrencyServices
    {
        Task<IEnumerable<Models.DTO.Currency>> GetAllAsync();
        Task<Models.DTO.Currency?> GetByIdAsync(Guid id);
        Task<Models.DTO.Currency> CreateAsync(Models.DTO.Currency currency);
        Task<Models.DTO.Currency> UpdateAsync(Guid id, Models.DTO.Currency currency);
        Task<bool> DeleteAsync(Guid id);
        Task CreateAsync(CurrencyRequest request);
        Task UpdateAsync(Guid id, CurrencyRequest request);
    }
}