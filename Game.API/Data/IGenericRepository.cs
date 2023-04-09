using System.Linq;
using System.Linq.Expressions;

namespace Game.API.Data;

public interface IGenericRepository<T> where T : class
{
    Task<IList<T>> FindAll(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, List<string>? includes);
    Task<T> Find(Expression<Func<T, bool>> expression, List<string>? includes);
    Task Add(T entity);
    Task AddRange(IEnumerable<T> entities);
    void Update(T entity);
    Task Remove(int id);
    void RemoveRange(IEnumerable<T> entities);
}