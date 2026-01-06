using CompanyModule.Models.POCO.Request.Country;
using CompanyModule.Models.POCO.Response.Country;

namespace CompanyModule.Interface.Services.Country
{
    public interface ICountryServices
    {
        Task<List<CountryResponse>> GetAllAsync();
        Task<CountryResponse?> GetByIdAsync(Guid id);
        Task CreateAsync(CountryRequest request);
        Task UpdateAsync(Guid id, CountryRequest request);
        Task DeleteAsync(Guid id);
    }
}
