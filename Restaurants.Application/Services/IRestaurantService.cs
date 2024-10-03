
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Services;
public interface IRestaurantService
{
    /// <summary>
    /// Retrieve all Restaurants in the data store.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
    /// <summary>
    /// Get the restaurant having the provided id from the data store.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Restaurant?> GetRestaurantByIdAsync(int id);
}