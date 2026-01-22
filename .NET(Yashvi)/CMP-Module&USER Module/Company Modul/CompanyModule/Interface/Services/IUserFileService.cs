using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Services
{
    public interface IUserFileService
    {
        Task<IEnumerable<UserFile>> GetAllAsync();
        Task<UserFile?> GetByIdAsync(Guid id);
        Task<IEnumerable<UserFile>> GetByUserIdAsync(Guid userId);
        Task<UserFile> CreateAsync(UserFile userFile);
        Task<UserFile> UpdateAsync(UserFile userFile);
        Task<bool> DeleteAsync(Guid id);
    }
}