using Game.API.Models.Enums;
using Mapster;

using Type = Game.API.Models.Enums.Type;

namespace Game.API.Contracts.Item;

public record UpdateItemRequest
{
    [AdaptIgnore(MemberSide.Source)]
    public Guid Id { get; private init; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Type Type { get; set; }
    public required Element Element { get; set; }
    public required decimal Price { get; set; }
}
