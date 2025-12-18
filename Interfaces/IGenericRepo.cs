using System.Linq.Expressions;

namespace lms_auth_be.Interfaces;

public interface IGenericRepo<T> where T : class
{
    Task Create(T entity);
    Task DeleteById(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter);
    Task<T?> GetById(int id);
    Task<T?> GetOne(Expression<Func<T, bool>> filter);
    Task SaveAsync();
}
