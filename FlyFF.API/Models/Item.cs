using System.ComponentModel.DataAnnotations;

namespace FlyFF.API.Models;

public class Item
{
    [Key]
    public Guid Id { get; private init; } = Guid.NewGuid();
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public DateTime Timestamp { get; private init; } = DateTime.UtcNow;
}