using Game.API.Models;
using MediatR;

namespace Game.API.Data.Queries;

public record GetItemQuery(Guid Id) : IRequest<Item>;
