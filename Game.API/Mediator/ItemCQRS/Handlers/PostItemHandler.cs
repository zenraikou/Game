using Game.API.Mediator.ItemCQRS.Commands;
using Game.API.Models;
using Game.API.Persistence.IRepository;
using MediatR;

namespace Game.API.Mediator.ItemCQRS.Handlers;

public class PostItemHandler : IRequestHandler<PostItemCommand, Item>
{
    private readonly IUnitOfWork _unitOfWork;

    public PostItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Item> Handle(PostItemCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Items.PostAsync(request.Item);
        await _unitOfWork.SaveAsync();
        return await Task.FromResult(request.Item);
    }
}
