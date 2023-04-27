using Game.API.Mediator.ItemCQRS.Queries;
using Game.API.Models;
using Game.API.Persistence.IRepository;
using MediatR;

namespace Game.API.Mediator.ItemCQRS.Handlers;

public class GetItemsHandler : IRequestHandler<GetItemsQuery, List<Item>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetItemsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Item>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Items.GetAllAsync();
    }
}
