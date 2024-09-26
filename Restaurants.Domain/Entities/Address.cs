namespace Restaurants.Domain.Entities;
/// <summary>
/// A standard street address
/// </summary>
public class Address
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? CountryCode { get; set; }
}
