﻿using Game.API.Data.IRepository;
using Game.API.Mediator.Items.Queries;
using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.Items.Handlers;

public class GetItemQueryHandler : IRequestHandler<GetItemQuery, Item?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetItemQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Item?> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Items.GetAsync(i => i.Id == request.Id);
    }
}