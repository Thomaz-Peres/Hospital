using System.Linq.Expressions;

namespace Doctors.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class 
    {
        Task AddAsync(T obj);
        Task UpdateAsync(T newObj);
        Task<T?> GetAsync(T obj);
        Task RemoveAsync(T obj);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filterExpression, params Expression<Func<T, object>>[] includes);
        Task<T?> FindAsync(Expression<Func<T, bool>> filterExpression, params Expression<Func<T, object>>[] includes);
    }
}
