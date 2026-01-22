using CompanyModule.Common;
using CompanyModule.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CompanyModule.Domain
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext context;
        protected readonly DbSet<T> dbSet;
        private readonly Func<CacheTech, ICacheService> _cacheServiceFactory;

        public GenericRepository(ApplicationContext context, Func<CacheTech, ICacheService> cacheServiceFactory)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            _cacheServiceFactory = cacheServiceFactory;
        }

        public virtual async Task<T> Insert(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual void MarkPropertyModified(T entity, string propertyName)
        {
            context.Entry(entity).Property(propertyName).IsModified = true;
        }
    }
}