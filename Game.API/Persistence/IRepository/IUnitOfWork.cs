namespace Game.API.Persistence.IRepository;

public interface IUnitOfWork /*: IDisposable*/
{
    IItemRepository Items { get; }

    Task SaveAsync();
}
