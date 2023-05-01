using Game.API.Models.Enums;

using Type = Game.API.Models.Enums.Type;

namespace Game.API.Models;

public record Item
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Type Type { get; set; }
    public required Element Element { get; set; }
    public required decimal Price { get; set; }
    public DateTime Timestamp { get; private init; } = DateTime.UtcNow;
}
