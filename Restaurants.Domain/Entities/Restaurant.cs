namespace Restaurants.Domain.Entities;

/// <summary>
/// Represents a restaurant
/// </summary>
public class Restaurant
{
    /// <summary>
    /// Unique identifier for the Restaurant
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Name of the Restaurant
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// Description of the Restaurant, e.g., "Roach Coach"
    /// </summary>
    public string Description { get; set; } = default!;
    /// <summary>
    /// Category of the Restaurant, e.g., "Tex-Mex"
    /// </summary>
    public string Category { get; set; } = default!;
    /// <summary>
    /// Do they deliver?
    /// </summary>
    public bool HasDelivery { get; set; }

    /// <summary>
    /// email address
    /// </summary>
    public string? ContactEmail { get; set; }
    /// <summary>
    /// phone number
    /// </summary>
    public string? ContactPhoneNumber { get; set; }
    /// <summary>
    /// Street Address
    /// </summary>
    public Address? Address { get; set; }
    /// <summary>
    /// List of dishes on the menu
    /// </summary>
    public List<Dish> Dishes { get; set; } = [];

}
