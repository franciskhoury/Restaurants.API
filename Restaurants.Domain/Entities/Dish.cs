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
    /// Price of the Dish in USD
    /// </summary>
    public decimal Price { get; set; }
}
