using Game.API.Data.Commands;
using Game.API.Data.IRepository;
using Game.API.Models;
using MediatR;

namespace Game.API.Data.Handlers;

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
