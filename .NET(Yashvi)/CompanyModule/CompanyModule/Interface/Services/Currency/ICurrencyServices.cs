using CompanyModule.Models.POCO.Request.Currency;
using CompanyModule.Models.POCO.Response.Currency;

namespace CompanyModule.Interface.Services.Currency
{
    public interface ICurrencyServices
    {
        Task<List<CurrencyResponse>> GetAllAsync();
        Task<CurrencyResponse?> GetByIdAsync(Guid id);
        Task CreateAsync(CurrencyRequest request);
        Task UpdateAsync(Guid id, CurrencyRequest request);
        Task DeleteAsync(Guid id);
    }
}
