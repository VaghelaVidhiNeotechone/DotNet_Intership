using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface ICompanyAttachmentRepository
    {
        Task AddAsync(CompanyAttachment attachment);
        Task<CompanyAttachment> GetByIdAsync(Guid attachmentId);
        Task<IEnumerable<CompanyAttachment>> GetAllByCompanyIdAsync(Guid companyId);
        Task UpdateAsync(CompanyAttachment attachment);
        Task DeleteAsync(Guid attachmentId);
    }
}
