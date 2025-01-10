
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;
internal class DishRepository(RestaurantDbContext dbContext) : IDishRepository
{
    public async Task<int> CreateAsync(Dish dishEntity)
    {
        _ = dbContext.Dish.Add(dishEntity);
        _ = await dbContext.SaveChangesAsync();
        return dishEntity.Id;
    }
}
