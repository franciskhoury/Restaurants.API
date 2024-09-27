namespace Restaurants.Domain.Entities;
public class Dish
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
}
