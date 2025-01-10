using MediatR;

using Microsoft.AspNetCore.Mvc;

using Restaurants.Application.Commands.Restaurants;
using Restaurants.Application.Queries.Restaurants;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantController(IMediator mediator) : Controller
{
    /// <summary>
    /// Retrieve all Restaurants from the data store asynchronously.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllRestaurants()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }

    /// <summary>
    /// Retrieve the Restaurant from the data store for the provided ID.
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurantById([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        return Ok(restaurant);
    }

    /// <summary>
    /// Remove the Restaurant from the data store for the provided ID.
    /// </summary>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        await mediator.Send(new DeleteRestaurantCommand(id));

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, UpdateRestaurantCommand command)
    {
        command.Id = id;
        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Create a new Restaurant in the data store.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    //[HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
    {
        // Manual validation not needed if class deocrated with [ApiCOntroller]
        //
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
    }
}
