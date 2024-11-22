using Microsoft.EntityFrameworkCore;

using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;
public class RestaurantCategoryRepository(RestaurantDbContext dbContext) : IRestaurantCategoryRepository
{
    public IEnumerable<string> GetAllRestaurantCategories()
    {
        return dbContext.RestaurantCategory
            .Select(c => c.Name)
            .ToList();
    }

    public async Task<IEnumerable<string>> GetAllRestaurantCategoriesAsync(CancellationToken cancellationToken)
    {
        return await dbContext.RestaurantCategory
                               .Select(c => c.Name)
                               .ToListAsync(cancellationToken);
    }


}
