using Advanced_Repository_Techniques.Data;
using Advanced_Repository_Techniques.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Advanced_Repository_Techniques.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync(); 
        }

        public async Task<IEnumerable<T>> GetAllIncludingDeletedAsync()
        {
            return await _dbSet.IgnoreQueryFilters().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is SoftDeleteEntity s && s.IsDeleted) return null;
            return entity;
        }

        public async Task<T?> GetByIdIncludingDeletedAsync(object id)
        {
            return await _dbSet
                .IgnoreQueryFilters() 
                .FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == (int)id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            if (entity is SoftDeleteEntity soft)
            {
                soft.IsDeleted = true;
                soft.DeletedAt = DateTime.UtcNow;
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity); 
            }
        }

        public async Task SoftDeleteAsync(T entity)
        {
            if (entity is SoftDeleteEntity soft)
            {
                soft.IsDeleted = true;
                soft.DeletedAt = DateTime.UtcNow;
                _dbSet.Update(entity);
                await Task.CompletedTask;
            }
            else
            {
                throw new InvalidOperationException("Entity does not support soft delete");
            }
        }

        public async Task RestoreAsync(T entity)
        {
            if (entity is SoftDeleteEntity soft)
            {
                soft.IsDeleted = false;
                soft.DeletedAt = null;
                _dbSet.Update(entity);
                await Task.CompletedTask;
            }
            else
            {
                throw new InvalidOperationException("Entity does not support restore");
            }
        }

        public async Task HardDeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }






        public async Task<IEnumerable<Product>> GetProductsByNameSP(string name)
        {
            return await _context.Set<Product>()
                .FromSqlRaw(
                    "EXEC GetProductByName @Name",
                    new SqlParameter("@Name", name)
                )
                .IgnoreQueryFilters()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsRawSql()
        {
            return await _context.Set<Product>()
                .FromSqlRaw("SELECT * FROM Products WHERE IsDeleted = 0")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> UpdateProductPriceRaw(int id, decimal price)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "UPDATE Products SET Price = @price WHERE Id = @id",
                new SqlParameter("@price", price),
                new SqlParameter("@id", id)
            );
        }



    }
}
