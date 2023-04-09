using System.ComponentModel.DataAnnotations;

namespace Game.API.Models.DTOs;

public record ItemDTO
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; private init; } = Guid.NewGuid();
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
}