using CompanyModule.Domain.Data;
using CompanyModule.Interface.Repository;
using CompanyModule.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CompanyModule.Domain
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationContext _context;

        public UserRoleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole?> GetByIdAsync(Guid id)
        {
            return await _context.UserRoles.FirstOrDefaultAsync(r => r.roleid == id);
        }

        public async Task<UserRole> CreateAsync(UserRole entity)
        {
            entity.roleid = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            
            _context.UserRoles.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UserRole> UpdateAsync(UserRole entity)
        {
            _context.UserRoles.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.UserRoles.FindAsync(id);
            if (entity == null) return false;

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.UserRoles.AnyAsync(r => r.roleid == id);
        }
    }
}