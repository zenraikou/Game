using Game.API.Data.IRepository;
using Game.API.Models;

namespace Game.API.Data.Repository;

public class ItemRepository : Repository<Item>, IItemRepository
{

    public ItemRepository(GameContext context) : base(context)
    {
    }
}
