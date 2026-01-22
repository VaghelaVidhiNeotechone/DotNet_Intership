using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface ICompanyAttachmentRepository
    {
        Task<IEnumerable<CompanyAttachment>> GetAllAsync();
        Task<CompanyAttachment?> GetByIdAsync(Guid id);
        Task<IEnumerable<CompanyAttachment>> GetByCompanyIdAsync(Guid companyId);
        Task<CompanyAttachment> CreateAsync(CompanyAttachment entity);
        Task<CompanyAttachment> UpdateAsync(CompanyAttachment entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}