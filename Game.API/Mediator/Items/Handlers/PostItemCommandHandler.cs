using Game.API.Data.IRepository;
using Game.API.Mediator.Items.Commands;
using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.Items.Handlers;

public class PostItemCommandHandler : IRequestHandler<PostItemCommand, Item>
{
    private readonly IUnitOfWork _unitOfWork;

    public PostItemCommandHandler(IUnitOfWork unitOfWork)
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
