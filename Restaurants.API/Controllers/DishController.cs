using MediatR;

using Microsoft.AspNetCore.Mvc;

using Restaurants.Application.Commands.Dishes;

namespace Restaurants.API.Controllers;

[Route("api/restaurants/{restaurantId}/dishes")]
[ApiController]
public class DishController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        await mediator.Send(command);
        return Created();
    }
}
