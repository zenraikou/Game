using System.Linq;
using System.Linq.Expressions;

namespace Game.API.Data;

public interface IGenericRepository<T> where T : class
{
    //Task<IList<T>> FindAll(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, List<string>? includes);
    //Task<T> Find(Expression<Func<T, bool>> expression, List<string>? includes);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null!);
    Task<T> GetAsync(Expression<Func<T, bool>> expression = null!, bool tracked = true);
    Task PostAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveAsync();
}
