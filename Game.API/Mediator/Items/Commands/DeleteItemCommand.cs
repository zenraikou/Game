using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.Items.Commands;

public record DeleteItemCommand(Item Item) : IRequest<Item>;
