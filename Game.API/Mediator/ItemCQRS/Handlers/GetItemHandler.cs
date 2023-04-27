using Game.API.Mediator.ItemCQRS.Queries;
using Game.API.Models;
using Game.API.Persistence.IRepository;
using MediatR;

namespace Game.API.Mediator.ItemCQRS.Handlers;

public class GetItemHandler : IRequestHandler<GetItemQuery, Item?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Item?> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Items.GetAsync(i => i.Id == request.Id);
    }
}
