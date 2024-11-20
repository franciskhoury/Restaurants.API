using Microsoft.EntityFrameworkCore;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;
internal class RestaurantRepository(RestaurantDbContext dbContext) : IRestaurantRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurant.ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        var restaurant = await dbContext.Restaurant.Where(r => r.Id == id)
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync();
        return restaurant;
    }
    /// <summary>
    /// Add a Restaurant entity to the repository and get/return the id of the new restaurant.
    /// </summary>
    /// <param name="restaurant"></param>
    /// <returns></returns>
    public async Task<int> CreateAsync(Restaurant restaurant)
    {
        _ = dbContext.Restaurant.Add(restaurant);
        _ = await dbContext.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task Delete(Restaurant restaurant)
    {
        _ = dbContext.Remove(restaurant);
        _ = await dbContext.SaveChangesAsync();
    }

    public async Task SaveChanges()
        => dbContext.SaveChanges();
}
