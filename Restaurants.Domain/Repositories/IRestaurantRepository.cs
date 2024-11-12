using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
public interface IRestaurantRepository
{
    /// <summary>
    /// Retrieve all Restaurants in the data store.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Restaurant>> GetAllAsync();
    /// <summary>
    /// Get the restaurant having the provided id from the data store.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Restaurant?> GetByIdAsync(int id);
    /// <summary>
    /// Add a restaurant to the repository and return the id of the new restaurant.
    /// </summary>
    /// <param name="restaurant"></param>
    /// <returns></returns>
    Task<int> CreateAsync(Restaurant restaurant);
}
