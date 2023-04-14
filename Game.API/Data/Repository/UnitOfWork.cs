using Game.API.Data.IRepository;

namespace Game.API.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly GameContext _context;

    public IItemRepository Items { get; private set; }

    public UnitOfWork(GameContext context)
    {
        _context = context;

        Items = new ItemRepository(_context);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    /*public void Dispose()
    {
        _context.Dispose();
    }*/
}
