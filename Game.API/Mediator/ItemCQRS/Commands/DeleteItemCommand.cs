using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.ItemCQRS.Commands;

public record DeleteItemCommand(Item Item) : IRequest<Item>;
