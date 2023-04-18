using Game.API.Models;
using MediatR;

namespace Game.API.Data.Commands;

public record DeleteItemCommand(Item Item) : IRequest<Item>;
