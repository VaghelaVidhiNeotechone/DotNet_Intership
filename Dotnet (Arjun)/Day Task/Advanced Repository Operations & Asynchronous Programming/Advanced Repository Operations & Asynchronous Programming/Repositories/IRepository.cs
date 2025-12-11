//using Advanced_Repository_Operations___Asynchronous_Programming.Dtos;
//using System.Linq.Expressions;

//namespace Advanced_Repository_Operations___Asynchronous_Programming.Repositories
//{
//    public interface IRepository<T> where T : class
//    {
//        Task<IEnumerable<T>> GetAllAsync();
//        Task<T?> GetByIdAsync(object id);
//        Task AddAsync(T entity);
//        void Update(T entity);
//        void Remove(T entity);
//        Task<bool> SaveChangesAsync();
//        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
//    }
//}




using System.Linq.Expressions;

namespace Advanced_Repository_Operations___Asynchronous_Programming.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T?> GetByIdAsync(object id);

        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<bool> SaveChangesAsync();

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
