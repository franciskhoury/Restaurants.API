using Microsoft.AspNetCore.Mvc;

using Restaurants.Application.Services;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantController(IRestaurantService restaurantService) : Controller
{
    /// <summary>
    /// Retrieve all Restaurants from the data store asynchronously.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var restaurants = await restaurantService.GetAllRestaurantsAsync();
        return Ok(restaurants);
    }
}
