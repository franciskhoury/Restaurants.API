using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.DTOs;

/// <summary>
/// DTO class for adding a new Restaurant
/// </summary>
public class RestaurantCreationDTO
{

    // Non-nullable properties set to default can be enforeced as "required"
    // in the controller by either decorating the class as ApiController or
    // by manually checking the ModelState.

    /// <summary>
    /// Unique identifier for the Restaurant
    /// </summary>
    //public int Id { get; set; }
    /// <summary>
    /// Name of the Restaurant
    /// </summary>
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = default!;
    /// <summary>
    /// Description of the Restaurant, e.g., "Roach Coach"
    /// </summary>
    [Required(ErrorMessage = "A valid Description is required.")]
    public string Description { get; set; } = default!;
    /// <summary>
    /// Category of the Restaurant, e.g., "Tex-Mex"
    /// </summary>
    [Required(ErrorMessage = "A valid Category is required.")]
    public string Category { get; set; } = default!;
    /// <summary>
    /// Do they deliver?
    /// </summary>
    public bool HasDelivery { get; set; }

    /// <summary>
    /// email address
    /// </summary>
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? ContactEmail { get; set; }

    /// <summary>
    /// phone number
    /// </summary>
    [Phone(ErrorMessage = "Invalid phone number.")]
    public string? ContactPhoneNumber { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    [RegularExpression(@"/^[ABCEGHJ-NPRSTVXY]\d[ABCEGHJ-NPRSTV-Z][-]?\d[ABCEGHJ-NPRSTV-Z]\d$/i")]
    //  | (^\d{5} +([-]?\d{4})?$) 
    public string? PostalCode { get; set; }

    [StringLength(2, MinimumLength = 2)]
    public string? CountryCode { get; set; }
}
