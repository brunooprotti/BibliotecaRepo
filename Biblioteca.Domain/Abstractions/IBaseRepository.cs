using System.Linq.Expressions;

namespace Biblioteca.Domain.Abstractions;

public interface IBaseRepository<T> where T : class
{
    Task<ICollection<T>> GetAll();
    Task<ICollection<T>> Get(Expression<Func<T, bool>> expression);
    Task<bool> Create(T entity);
}

