
namespace Restaurants.Domain.Repositories;
public interface IRestaurantCategoryRepository
{
    IEnumerable<string> GetAllRestaurantCategories();
    Task<IEnumerable<string>> GetAllRestaurantCategoriesAsync(CancellationToken cancellationToken);
}


