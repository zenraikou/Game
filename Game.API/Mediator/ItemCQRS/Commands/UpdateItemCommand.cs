using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.ItemCQRS.Commands;

public record UpdateItemCommand(Item Item) : IRequest<Item>;
