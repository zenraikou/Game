namespace Game.API.Models;

public record Account
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public required string Username { get; set; }
    public required string Password { get; set; }
}
