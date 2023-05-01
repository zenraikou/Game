using Mapster;

namespace Game.API.Contracts.Account;

public record GetAccountResponse
{
    [AdaptIgnore(MemberSide.Source)]
    public Guid Id { get; private init; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}
