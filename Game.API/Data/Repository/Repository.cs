using Game.API.Data.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Game.API.Data.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly GameContext _context;
    private readonly DbSet<T> _db;

    public Repository(GameContext context)
    {
        _context = context;
        _db = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>? expression, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, 
        List<string>? includes)
    {
       IQueryable<T> query = _db;

       if (expression is not null)
       {
           query = query.Where(expression);
       }

       if (includes is not null)
       {
           foreach (var property in includes)
           {
               query = query.Include(property);
           }
       }

       if (orderBy is not null)
       {
           query = orderBy(query);
       }

       return await query.AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>>? expression, List<string>? includes)
    {
        IQueryable<T> query = _db;

        if (expression is not null)
        {
            query = query.Where(expression);
        }

        if (includes is not null)
        {
           foreach (var property in includes)
           {
               query = query.Include(property);
           }
        }

        return await query.AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task PostAsync(T entity)
    {
        await _db.AddAsync(entity);
        await SaveAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _db.Update(entity);
        await SaveAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _db.Remove(entity);
        await SaveAsync();
    }
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
