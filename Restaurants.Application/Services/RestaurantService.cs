using AutoMapper;

using Microsoft.Extensions.Logging;

using Restaurants.Application.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Services;

internal class RestaurantService(IRestaurantRepository restaurantRepository,
                                 ILogger<RestaurantService> logger,
                                 IMapper mapper) : IRestaurantService
{
    public async Task<int> CreateRestaurantAsync(RestaurantCreationDTO dto)
    {
        logger.LogInformation("Creating a new restaurant.");
        var restaurant = mapper.Map<Restaurant>(dto);
        int id = await restaurantRepository.CreateAsync(restaurant);

        return id;

    }

    public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurantsAsync()
    {
        logger.LogInformation("Getting all restaurants.");
        var restaurants = await restaurantRepository.GetAllAsync();

        // Old approach, "manual" mapping
        //var restaurantsDTOs = restaurants.Select(RestaurantDTO.FromEntity);

        // New approach using Automapper
        var restaurantsDTOs = mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);

        return restaurantsDTOs!;
    }

    public async Task<RestaurantDTO?> GetRestaurantByIdAsync(int id)
    {
        logger.LogInformation($"Getting restaurant with id = {id}.");
        var restaurant = await restaurantRepository.GetByIdAsync(id);

        // Old approach, "manual" mapping
        //var restaurantDTO = RestaurantDTO.FromEntity(restaurant);

        // New approach using Automapper
        var restaurantDTO = mapper.Map<RestaurantDTO>(restaurant);

        return restaurantDTO;
    }
}
