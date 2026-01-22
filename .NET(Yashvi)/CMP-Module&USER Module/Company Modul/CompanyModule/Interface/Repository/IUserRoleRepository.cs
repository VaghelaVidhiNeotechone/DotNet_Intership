using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole?> GetByIdAsync(Guid id);
        Task<UserRole> CreateAsync(UserRole entity);
        Task<UserRole> UpdateAsync(UserRole entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}