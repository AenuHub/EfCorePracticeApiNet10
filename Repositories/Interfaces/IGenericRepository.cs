using System.Linq.Expressions;

namespace EfCorePracticeApiNet10.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
