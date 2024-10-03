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

    public async Task<Restaurant> GetByIdAsync(int id)
    {
        var restaurant = await dbContext.Restaurant.Where(r => r.Id == id).FirstOrDefaultAsync();
        return restaurant;
    }
}
