using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
public interface IDishRepository
{
    /// <summary>
    /// Add a dish to a restaurant in the repository and return the id of the new restaurant.
    /// </summary>
    /// <returns></returns>
    Task<int> CreateAsync(Dish entity);
}
