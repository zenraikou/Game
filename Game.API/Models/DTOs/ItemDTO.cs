using Game.API.Models.Enums;
using Mapster;
using System.ComponentModel.DataAnnotations;

namespace Game.API.Models.DTOs;

public class ItemDTO
{
    [Key]
    [AdaptIgnore(MemberSide.Source)]
    public Guid Id { get; private init; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public required Category Category { get; set; }
    [Required]
    public required Element Element { get; set; }
    [Required]
    public required decimal Price { get; set; }
}
