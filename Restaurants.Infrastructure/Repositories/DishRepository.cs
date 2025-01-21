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

    //public async Task<IEnumerable<Dish>> GetDishesForRestaurant(int restaurantId)
    //{
    //    var restaurant = await dbContext.Restaurant.Where(r => r.Id == restaurantId)
    //        .Include(r => r.Dishes)
    //        .FirstOrDefaultAsync();

    //    return restaurant != null ? restaurant.Dishes :
    //        throw new NotFoundException(nameof(Restaurant), restaurantId.ToString());
    //}
}
