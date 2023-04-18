﻿using Game.API.Data.Commands;
using Game.API.Data.IRepository;
using Game.API.Models;
using MediatR;

namespace Game.API.Data.Handlers;

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