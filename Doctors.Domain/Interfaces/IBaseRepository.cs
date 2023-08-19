using System.Linq.Expressions;

namespace Doctors.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class 
    {
        Task AddAsync(T obj);
        Task UpdateAsync(T obj);
        Task<T?> GetAsync(T obj);
        Task RemoveAsync(T obj);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> FindAsync(Expression<Func<T, bool>> filterExpression, params Expression<Func<T, object>>[] includes);
    }
}
