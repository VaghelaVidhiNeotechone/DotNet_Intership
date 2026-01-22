using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface IOtpMasterRepository
    {
        Task<OtpMaster> Insert(OtpMaster entity);
        Task<OtpMaster> Update(OtpMaster entity);
        Task<bool> Delete(Guid id);
        Task<OtpMaster> GetById(Guid id);
        IQueryable<OtpMaster> GetAll();
        Task<OtpMaster> GetByUserIdAndOtp(Guid userId, string otp);
    }
}