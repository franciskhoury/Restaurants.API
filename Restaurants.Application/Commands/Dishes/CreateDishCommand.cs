using MediatR;

namespace Restaurants.Application.Commands.Dishes;
public class CreateDishCommand : IRequest
{
    /// <summary>
    /// Name of the Dish
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// Description of the Dish
    /// </summary>
    public string Description { get; set; } = default!;
    /// <summary>
    /// Food Calories of the dish
    /// </summary>
    public int? Calories { get; set; }
    /// <summary>
    /// Price of the Dish in USD
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// Unique identifier of the restaurant that serves this dish.
    /// </summary>
    public int RestaurantId { get; set; }
}
