using Game.API.Models;
using MediatR;

namespace Game.API.Data.Commands;

public record PostItemCommand(Item Item) : IRequest<Item>;
