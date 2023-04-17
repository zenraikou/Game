using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.Items.Queries;

public record GetItemsQuery : IRequest<List<Item>>;
