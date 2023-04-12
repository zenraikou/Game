using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Game.API.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly GameContext _context;
    private readonly DbSet<T> _db;

    public GenericRepository(GameContext context)
    {
        _context = context;
        _db = _context.Set<T>();
    }

    //public async Task<IList<T>> FindAll(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, List<string>? includes)
    //{
    //    IQueryable<T> query = _db;

    //    if (expression is not null)
    //    {
    //        query = query.Where(expression);
    //    }

    //    if (includes is not null)
    //    {
    //        foreach (var property in includes)
    //        {
    //            query = query.Include(property);
    //        }
    //    }

    //    if (orderBy is not null)
    //    {
    //        query = orderBy(query);
    //    }

    //    return await query.AsNoTracking().ToListAsync();
    //}

    //public async Task<T> Find(Expression<Func<T, bool>> expression, List<string>? includes)
    //{
    //    IQueryable<T> query = _db;

    //    if (includes is not null)
    //    {
    //        foreach (var property in includes)
    //        {
    //            query = query.Include(property);
    //        }
    //    }

    //    return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    //}

    //public async Task Remove(int id)
    //{
    //    var entity = await _db.FindAsync(id);
    //    _db.Remove(entity);
    //}

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
    {
        IQueryable<T> query = _db;

        if (expression is not null)
        {
            query = query.Where(expression);
        }

        return await query.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool tracked)
    {
        IQueryable<T> query = _db;

        if (tracked is false)
        {
            query = query.AsNoTracking();
        }

        if (expression is not null)
        {
            query = query.Where(expression);
        }

        return await query.FirstOrDefaultAsync();
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
