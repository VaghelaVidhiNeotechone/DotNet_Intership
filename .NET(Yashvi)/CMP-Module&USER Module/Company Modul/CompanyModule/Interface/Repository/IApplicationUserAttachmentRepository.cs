using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface IApplicationUserAttachmentRepository
    {
        Task<ApplicationUserAttachment> Insert(ApplicationUserAttachment entity);
        Task<ApplicationUserAttachment> Update(ApplicationUserAttachment entity);
        Task<bool> Delete(Guid id);
        Task<ApplicationUserAttachment> GetById(Guid id);
        IQueryable<ApplicationUserAttachment> GetAll();
        IQueryable<ApplicationUserAttachment> GetByUserId(Guid userId);
    }
}