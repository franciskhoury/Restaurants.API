using Microsoft.Extensions.Logging;

using Restaurants.Application.Services.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Services;

internal class RestaurantService(IRestaurantRepository restaurantRepository, ILogger<RestaurantService> logger) : IRestaurantService
{
    public async Task<int> CreateRestaurantAsync(RestaurantCreationDTO dto)
    {
        logger.LogInformation("Creating a new restaurant.");
        // Map the DTO to the Entity model.
        var restaurant = new { }
        await restaurantRepository.CreateAsync(dto);
    }

    public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurantsAsync()
    {
        logger.LogInformation("Getting all restaurants.");
        var restaurants = await restaurantRepository.GetAllAsync();
        var restaurantsDTOs = restaurants.Select(RestaurantDTO.FromEntity);
        return restaurantsDTOs!;
    }

    public async Task<RestaurantDTO?> GetRestaurantByIdAsync(int id)
    {
        logger.LogInformation($"Getting restaurant with id = {id}.");
        var restaurant = await restaurantRepository.GetByIdAsync(id);
        var restaurantDTO = RestaurantDTO.FromEntity(restaurant);
        return restaurantDTO;
    }
}
