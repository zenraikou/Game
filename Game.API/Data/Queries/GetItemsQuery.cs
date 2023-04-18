using Game.API.Models;
using MediatR;

namespace Game.API.Data.Queries;

public record GetItemsQuery : IRequest<List<Item>>;
