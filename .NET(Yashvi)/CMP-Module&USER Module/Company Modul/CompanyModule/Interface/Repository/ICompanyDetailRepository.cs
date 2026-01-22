using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface ICompanyDetailRepository
    {
        Task<IEnumerable<CompanyDetailEntity>> GetAllAsync();
        Task<CompanyDetailEntity?> GetByIdAsync(Guid id);
        Task<CompanyDetailEntity> CreateAsync(CompanyDetailEntity entity);
        Task<CompanyDetailEntity> UpdateAsync(CompanyDetailEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}