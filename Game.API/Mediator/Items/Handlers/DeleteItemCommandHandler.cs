using Game.API.Data.IRepository;
using Game.API.Mediator.Items.Commands;
using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.Items.Handlers;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Item>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteItemCommandHandler(IUnitOfWork unitOfWork)
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
