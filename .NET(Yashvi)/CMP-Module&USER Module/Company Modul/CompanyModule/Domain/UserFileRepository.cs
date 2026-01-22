using CompanyModule.Domain.Data;
using CompanyModule.Interface.Repository;
using CompanyModule.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CompanyModule.Domain
{
    public class UserFileRepository : IUserFileRepository
    {
        private readonly ApplicationContext _context;

        public UserFileRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserFile>> GetAllAsync()
        {
            return await _context.UserFiles
                .Include(f => f.User)
                .ToListAsync();
        }

        public async Task<UserFile?> GetByIdAsync(Guid id)
        {
            return await _context.UserFiles
                .Include(f => f.User)
                .FirstOrDefaultAsync(f => f.userfileid == id);
        }

        public async Task<IEnumerable<UserFile>> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserFiles
                .Where(f => f.userid == userId)
                .ToListAsync();
        }

        public async Task<UserFile> CreateAsync(UserFile entity)
        {
            entity.userfileid = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            
            _context.UserFiles.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UserFile> UpdateAsync(UserFile entity)
        {
            _context.UserFiles.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.UserFiles.FindAsync(id);
            if (entity == null) return false;

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.UserFiles.AnyAsync(f => f.userfileid == id);
        }
    }
}