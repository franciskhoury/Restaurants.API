namespace Restaurants.Domain.Entities;

// Want to use this to validate Category when creating/updating a Restaurant
public class RestaurantCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}
