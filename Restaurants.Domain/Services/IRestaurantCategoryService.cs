
namespace Restaurants.Domain.Services;
public interface IRestaurantCategoryService
{
    IEnumerable<string> GetValidCategories();
    Task<IEnumerable<string>> GetValidCategoriesAsync(CancellationToken cancellationToken);
}
