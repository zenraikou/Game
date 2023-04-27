using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.ItemCQRS.Commands;

public record PostItemCommand(Item Item) : IRequest<Item>;
