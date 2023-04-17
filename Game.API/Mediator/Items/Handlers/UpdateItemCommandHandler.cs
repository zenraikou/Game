using Game.API.Data.IRepository;
using Game.API.Mediator.Items.Commands;
using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.Items.Handlers;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Item>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemCommandHandler(IUnitOfWork unitOfWork)
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
