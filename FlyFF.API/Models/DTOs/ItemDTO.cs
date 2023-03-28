using System.ComponentModel.DataAnnotations;

namespace FlyFF.API.Models.DTOs;

public class ItemDTO
{
    [Key]
    public Guid Id { get; private init; } = Guid.NewGuid();
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
}