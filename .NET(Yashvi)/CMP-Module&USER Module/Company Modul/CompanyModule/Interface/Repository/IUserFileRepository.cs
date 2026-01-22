using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface IUserFileRepository
    {
        Task<IEnumerable<UserFile>> GetAllAsync();
        Task<UserFile?> GetByIdAsync(Guid id);
        Task<IEnumerable<UserFile>> GetByUserIdAsync(Guid userId);
        Task<UserFile> CreateAsync(UserFile entity);
        Task<UserFile> UpdateAsync(UserFile entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}