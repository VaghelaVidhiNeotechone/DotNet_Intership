using Advanced_Repository_Techniques.Models;
using System.Linq.Expressions;

namespace Advanced_Repository_Techniques.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllIncludingDeletedAsync(); 
        Task<T?> GetByIdAsync(object id);
        Task<T?> GetByIdIncludingDeletedAsync(object id); 
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity); 
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task SoftDeleteAsync(T entity);     
        Task RestoreAsync(T entity);      
        Task HardDeleteAsync(T entity);

    }
}
