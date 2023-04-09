using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game.API.Models.DTOs;

public record ItemDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
}