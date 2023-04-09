using System.ComponentModel.DataAnnotations;

namespace Game.API.Models;

public record Item
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; private init; } = Guid.NewGuid();
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
    public DateTime Timestamp { get; private init; } = DateTime.UtcNow;
}