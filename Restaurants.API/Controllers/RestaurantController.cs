using Microsoft.AspNetCore.Mvc;

using Restaurants.Application.DTOs;
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

    /// <summary>
    /// Retrieve the Restaurant from the data store for the provided ID.
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var restaurant = await restaurantService.GetRestaurantByIdAsync(id);
        return restaurant is null ? NotFound($"No restaurant with id {id} exists in the data store.") : Ok(restaurant);
    }

    /// <summary>
    /// Create a new Restaurant in the data store.
    /// </summary>
    /// <param name="restaurantToCreate"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateRestaurantAsync(RestaurantCreationDTO restaurantToCreate)
    {
        // Manual validation not needed if class deocrated with [ApiCOntroller]
        //
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        int id = await restaurantService.CreateRestaurantAsync(restaurantToCreate);
        return CreatedAtAction(nameof(GetByIdAsync), new { id }, null);
    }
}
