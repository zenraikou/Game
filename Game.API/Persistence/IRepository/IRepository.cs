using System.Linq.Expressions;

namespace Game.API.Persistence.IRepository;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null/*, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<string>? includes = null*/);
    Task<T?> GetAsync(Expression<Func<T, bool>>? expression = null/*, List<string>? includes = null*/);
    Task PostAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
