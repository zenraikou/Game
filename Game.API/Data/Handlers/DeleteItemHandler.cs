using Game.API.Data.Commands;
using Game.API.Data.IRepository;
using Game.API.Models;
using MediatR;

namespace Game.API.Data.Handlers;

public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, Item>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Item> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.Items.Delete(request.Item);
        await _unitOfWork.SaveAsync();
        return await Task.FromResult(request.Item);
    }
}
