using Game.API.Models;
using MediatR;

namespace Game.API.Data.Commands;

public record UpdateItemCommand(Item Item) : IRequest<Item>;
