using Restaurants.Application.Services.DTOs;

namespace Restaurants.Application.Services;
public interface IRestaurantService
{
    /// <summary>
    /// Retrieve all Restaurants in the data store.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<RestaurantDTO>> GetAllRestaurantsAsync();
    /// <summary>
    /// Get the restaurant having the provided id from the data store.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<RestaurantDTO?> GetRestaurantByIdAsync(int id);
    /// <summary>
    /// Create a new restaurant from a DTO
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    //Task<int> CreateRestaurantAsync(RestaurantCreationDTO dto);
}