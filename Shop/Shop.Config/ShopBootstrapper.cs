﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application._Utilities;
using Shop.Application.Categories;
using Shop.Application.Products;
using Shop.Application.Roles.Create;
using Shop.Application.Sellers;
using Shop.Application.Users;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure;
using Shop.Query.Categories.GetById;

namespace Shop.Config;

public static class ShopBootstrapper
{
    public static void RegisterShopDependency(IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Init(services, connectionString);

        services.AddMediatR(typeof(Directories).Assembly);

        services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

        services.AddTransient<IProductDomainService, ProductDomainService>();
        services.AddTransient<IDomainUserService, DomainUserService>();
        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<ISellerDomainService, SellerDomainService>();


        services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);

    }
}