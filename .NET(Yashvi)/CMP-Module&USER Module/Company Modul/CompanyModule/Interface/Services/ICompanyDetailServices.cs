using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.CompanyDetail;

namespace CompanyModule.Interface.Services.CompanyDetail
{
    public interface ICompanyDetailServices
    {
        Task<IEnumerable<CompanyDetailEntity>> GetAllAsync();
        Task<CompanyDetailEntity?> GetByIdAsync(Guid id);
        Task<CompanyDetailEntity> CreateAsync(CompanyDetailEntity company);
        Task<CompanyDetailEntity> UpdateAsync(CompanyDetailEntity company);
        Task<bool> DeleteAsync(Guid id);
        Task<CompanyDetailEntity> AddAsync(CompanyDetailRequest request);
        Task GetAllCompaniesAsync();
        Task UpdateAsync(CompanyDetailRequest request);
        Task DeleteCompanyAsync(Guid id);
        Task<bool> CompanyExistsAsync(Guid id);
        Task UpdateCompanyAsync(CompanyDetailEntity company);
        Task CreateCompanyAsync(CompanyDetailEntity company);
        Task GetCompanyByIdAsync(Guid id);
    }
}