﻿using Game.API.Data.IRepository;
using Game.API.Data.Queries;
using Game.API.Models;
using MediatR;

namespace Game.API.Data.Handlers;

public class GetItemsHandler : IRequestHandler<GetItemsQuery, List<Item>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetItemsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Item>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Items.GetAllAsync();
    }
}