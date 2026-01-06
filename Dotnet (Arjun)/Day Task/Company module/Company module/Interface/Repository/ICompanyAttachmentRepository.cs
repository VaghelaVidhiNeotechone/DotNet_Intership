using Company_module.Models.DTO;

namespace Company_module.Interface.Repository
{
    public interface ICompanyAttachmentRepository
    {
        Task AddAsync(CompanyAttachment attachment);
        Task<CompanyAttachment> GetByIdAsync(Guid attachmentId);
        Task<IEnumerable<CompanyAttachment>> GetAllByCompanyIdAsync(Guid companyId);
        Task UpdateAsync(CompanyAttachment attachment);
        Task DeleteAsync(Guid attachmentId);


        Task<bool> CompanyExistsAsync(Guid companyId);
    }
}
