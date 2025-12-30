using Company_module.Models.DTO;

namespace Company_module.Interface.Repository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();
        Task<Country?> GetByIdAsync(Guid id);
        Task AddAsync(Country country);
        void Update(Country country);
        void Delete(Country country);


        Task<bool> ExistsAsync(Guid countryid);
        
        Task<Guid?> GetCountryIdByNameAsync(string countryName);
        Task<bool> CountryNameExistsAsync(string countryName);
        Task<bool> CountryNameExistsExceptIdAsync(string countryName, Guid id);

    }
}
