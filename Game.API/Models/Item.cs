using Game.API.Models.Enums;

namespace Game.API.Models;

public class Item
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Category Category { get; set; }
    public required Element Element { get; set; }
    public required decimal Price { get; set; }
    public DateTime Timestamp { get; private init; } = DateTime.UtcNow;
}
