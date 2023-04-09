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

    public async Task<IList<T>> FindAll(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, List<string>? includes)
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

    public async Task<T> Find(Expression<Func<T, bool>> expression, List<string>? includes)
    {
        IQueryable<T> query = _db;

        if (includes is not null)
        {
            foreach (var property in includes)
            {
                query = query.Include(property);
            }
        }

        return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task Add(T entity)
    {
        await _db.AddAsync(entity);
    }

    public async Task AddRange(IEnumerable<T> entities)
    {
        await _db.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _db.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task Remove(int id)
    {
        var entity = await _db.FindAsync(id);
        _db.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _db.RemoveRange(entities);
    }
}