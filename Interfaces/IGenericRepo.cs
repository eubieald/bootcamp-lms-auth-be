using System.Linq.Expressions;

namespace lms_auth_be.Interfaces;

public interface IGenericRepo<T> where T : class
{
    Task CreateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter);
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetOne(Expression<Func<T, bool>> filter);
    Task SaveAsync();
}
