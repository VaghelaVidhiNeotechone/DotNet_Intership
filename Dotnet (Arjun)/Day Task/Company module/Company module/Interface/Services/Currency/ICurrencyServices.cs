using Company_module.Models.POCO.Request.Currency;
using Company_module.Models.POCO.Response.Currency;

namespace Company_module.Interface.Services.Currency
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
