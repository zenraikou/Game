using Game.API.Mediator.ItemCQRS.Commands;
using Game.API.Models;
using Game.API.Persistence.IRepository;
using MediatR;

namespace Game.API.Mediator.ItemCQRS.Handlers;

public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, Item>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Item> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.Items.Update(request.Item);
        await _unitOfWork.SaveAsync();
        return await Task.FromResult(request.Item);
    }
}
