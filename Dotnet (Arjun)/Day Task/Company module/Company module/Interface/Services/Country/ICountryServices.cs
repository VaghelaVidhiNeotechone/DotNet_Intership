using Company_module.Models.POCO.Request.Country;
using Company_module.Models.POCO.Response.Country;

namespace Company_module.Interface.Services.Country
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
