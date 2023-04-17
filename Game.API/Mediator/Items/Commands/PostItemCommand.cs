using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.Items.Commands;

public record PostItemCommand(Item Item) : IRequest<Item>;
