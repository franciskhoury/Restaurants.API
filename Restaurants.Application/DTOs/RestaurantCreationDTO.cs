namespace Restaurants.Application.DTOs;

/// <summary>
/// DTO class for adding a new Restaurant
/// </summary>
public class RestaurantCreationDTO
{
    /// <summary>
    /// Unique identifier for the Restaurant
    /// </summary>
    //public int Id { get; set; }
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

    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? CountryCode { get; set; }
}
