using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.Items.Queries;

public record GetItemQuery(Guid Id) : IRequest<Item>;
