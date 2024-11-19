﻿using AquaEngine.API.Control.Domain.Model.Aggregates;
using AquaEngine.API.Control.Domain.Model.Queries;

namespace AquaEngine.API.Control.Domain.Services;

public interface IProductQueryService
{
    Task<IEnumerable<Product>> Handle(GetProductByUserIdQuery query);
    Task<Product?> Handle(GetProductByIdQuery query);
    Task<Product?> Handle(GetProductByNameQuery query);
    Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);
}