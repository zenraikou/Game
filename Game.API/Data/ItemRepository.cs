using Game.API.Models;

namespace Game.API.Data;

public class ItemRepository : GenericRepository<Item>, IItemRepository
{

    public ItemRepository(GameContext context) : base(context)
    {
    }
}
