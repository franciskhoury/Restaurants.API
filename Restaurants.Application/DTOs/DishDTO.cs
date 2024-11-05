using Restaurants.Domain.Entities;

namespace Restaurants.Application.DTOs;
public class DishDTO
{
    /// <summary>
    /// Unique ID fo the Dish
    /// </summary>
    public int Id { get; set; }
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
    /// Id of the Owning Restaurant (Foreign Key)
    /// </summary>
    public int RestaurantId { get; set; }

    /// <summary>
    /// Map the Dish entity to the DishDTO.
    /// Note - this logic can be replaced by using the Automapper Nuget package
    /// </summary>
    /// <param name="dish"></param>
    /// <returns></returns>
    public static DishDTO FromEntity(Dish dish)
    {
        return new DishDTO
        {
            Id = dish.Id,
            Name = dish.Name,
            Description = dish.Description,
            Calories = dish.Calories,
            Price = dish.Price,
        };
    }
}
