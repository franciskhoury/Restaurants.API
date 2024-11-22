
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Services;

namespace Restaurants.Application.Services;
public class RestaurantCategoryService : IRestaurantCategoryService
{
    private readonly IRestaurantCategoryRepository _repository;

    public RestaurantCategoryService(IRestaurantCategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<string>> GetValidCategoriesAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAllRestaurantCategoriesAsync(cancellationToken);
    }

    public IEnumerable<string> GetValidCategories()
    {
        return _repository.GetAllRestaurantCategories();
    }
}
