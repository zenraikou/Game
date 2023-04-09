using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game.API.Models;

public record Item
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime Timestamp { get; private init; } = DateTime.UtcNow;
}