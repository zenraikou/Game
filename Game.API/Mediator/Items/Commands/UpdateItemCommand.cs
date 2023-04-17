using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.Items.Commands;

public record UpdateItemCommand(Item Item) : IRequest<Item>;
