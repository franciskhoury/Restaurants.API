using Microsoft.AspNetCore.Mvc;

using Restaurants.Application.Services;
using Restaurants.Application.Services.DTOs;

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


    //[HttpPost]
    //public async Task<IActionResult> CreateAsync([FromBody] RestaurantCreationDTO dto)
    //{
    //    int id = await restaurantService.CreateRestaurantAsync(dto);
    //    return CreatedAtAction(nameof(GetByIdAsync), new { id }, null);
    //}
}
