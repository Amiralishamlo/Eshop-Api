﻿using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.OrderAgg;
using Shop.Infrastructure.Persistent.Ef.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.SellerAgg;
using Shop.Infrastructure.Persistent.Ef.SiteEntities.Repositories;
using Shop.Infrastructure.Persistent.Ef.UserAgg;

namespace Shop.Infrastructure;

public class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ISellerRepository, SellerRepository>();
        services.AddTransient<IBannerRepository, BannerRepository>();
        services.AddTransient<ISliderRepository, SliderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();


        //services.AddTransient(_ => new DapperContext(connectionString));
        services.AddDbContext<ShopContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}
