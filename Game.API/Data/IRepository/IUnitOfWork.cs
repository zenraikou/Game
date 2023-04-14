namespace Game.API.Data.IRepository;

public interface IUnitOfWork /*: IDisposable*/
{
    IItemRepository Items { get; }

    Task SaveAsync();
}
