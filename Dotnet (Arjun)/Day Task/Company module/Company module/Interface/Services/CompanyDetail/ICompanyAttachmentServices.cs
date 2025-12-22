using Company_module.Models.DTO;
using Company_module.Models.POCO.Request.CompanyDetail;

namespace Company_module.Interface.Services.CompanyDetail
{
    public interface ICompanyAttachmentServices
    {
        Task AddCompanyAttachment(CompanyAttachmentRequest request);
        Task<CompanyAttachment> GetAttachmentById(Guid attachmentId);
        Task<IEnumerable<CompanyAttachment>> GetAllAttachmentsByCompanyId(Guid companyId);
        Task UpdateAttachment(CompanyAttachmentRequest request);
        Task DeleteAttachment(Guid attachmentId);
    }
}
