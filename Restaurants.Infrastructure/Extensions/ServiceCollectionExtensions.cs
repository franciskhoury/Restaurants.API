﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("RestaurantsDb")!;
        _ = services.AddDbContext<RestaurantDbContext>(options =>
                          options.UseSqlServer(connectionString)
                          .EnableSensitiveDataLogging());
        _ = services.AddTransient<IRestaurantSeeder, RestaurantSeeder>();
        _ = services.AddScoped<IRestaurantRepository, RestaurantRepository>();
    }
}
