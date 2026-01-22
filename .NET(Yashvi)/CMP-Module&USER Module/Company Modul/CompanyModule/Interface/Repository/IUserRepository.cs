using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser?> GetByIdAsync(Guid id);
        Task<ApplicationUser> CreateAsync(ApplicationUser entity);
        Task<ApplicationUser> UpdateAsync(ApplicationUser entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}