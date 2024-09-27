using Microsoft.Extensions.Logging;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Services;

internal class RestaurantService(IRestaurantRepository restaurantRepository, ILogger<RestaurantService> logger) : IRestaurantService
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
    {
        logger.LogInformation("Getting all restaurants.");
        var restaurants = await restaurantRepository.GetAllAsync();
        return restaurants;
    }
}
