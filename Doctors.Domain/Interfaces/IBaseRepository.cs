using System.Linq.Expressions;

namespace Doctors.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class 
    {
        Task Add(T obj);
        Task Update(T obj);
        Task Remove(T obj);
        Task<IEnumerable<T>> GetAll();
        Task<T?> FindAsync(Expression<Func<T, bool>> filterExpression, params Expression<Func<T, object>>[] includes);
    }
}
