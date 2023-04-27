using Game.API.Models;
using Game.API.Persistence.IRepository;

namespace Game.API.Persistence.Repository;

public class ItemRepository : Repository<Item>, IItemRepository
{

    public ItemRepository(GameContext context) : base(context)
    {
    }
}
