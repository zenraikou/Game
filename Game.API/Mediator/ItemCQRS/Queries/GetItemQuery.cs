﻿using Game.API.Models;
using MediatR;

namespace Game.API.Mediator.ItemCQRS.Queries;

public record GetItemQuery(Guid Id) : IRequest<Item>;
