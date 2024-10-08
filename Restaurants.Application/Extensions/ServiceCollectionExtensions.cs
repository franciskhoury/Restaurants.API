﻿using Microsoft.Extensions.DependencyInjection;

using Restaurants.Application.Services;

namespace Restaurants.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        _ = services.AddScoped<IRestaurantService, RestaurantService>();
    }
}
