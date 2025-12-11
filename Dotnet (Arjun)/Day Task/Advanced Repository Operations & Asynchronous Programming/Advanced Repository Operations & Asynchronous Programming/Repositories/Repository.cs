//using Advanced_Repository_Operations___Asynchronous_Programming.Repositories;
//using Advanced_Repository_Operations___Asynchronous_Programming.Data;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq.Expressions;

//namespace Advanced_Repository_Operations___Asynchronous_Programming.Repositories
//{
//    public class Repository<T> : IRepository<T> where T : class
//    {
//        protected readonly AppDbContext _context;
//        protected readonly DbSet<T> _dbSet;

//        public Repository(AppDbContext context)
//        {
//            _context = context;
//            _dbSet = _context.Set<T>();
//        }

//        public async Task<IEnumerable<T>> GetAllAsync()
//        {
//            return await _dbSet.ToListAsync();
//        }

//        public async Task<T?> GetByIdAsync(object id)
//        {
//            return await _dbSet.FindAsync(id);
//        }

//        public async Task AddAsync(T entity)
//        {
//            await _dbSet.AddAsync(entity);
//        }

//        public void Update(T entity)
//        {
//            _dbSet.Update(entity);
//        }

//        public void Remove(T entity)
//        {
//            _dbSet.Remove(entity);
//        }

//        public async Task<bool> SaveChangesAsync()
//        {
//            return (await _context.SaveChangesAsync()) > 0;
//        }

//        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
//        {
//            return await _dbSet.Where(predicate).ToListAsync();
//        }
//    }
//}







using Advanced_Repository_Operations___Asynchronous_Programming.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Advanced_Repository_Operations___Asynchronous_Programming.Repositories
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

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
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
            _dbSet.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }
    }
}
