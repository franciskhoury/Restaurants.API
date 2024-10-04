using Restaurants.Domain.Entities;

namespace Restaurants.Application.Services.DTOs;

/// <summary>
/// Represents a Restaurant to a client
/// </summary>
public class RestaurantDTO
{
    /// <summary>
    /// Unique identifier for the RestaurantDTO
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
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? CountryCode { get; set; }
    /// <summary>
    /// List of dishes on the menu
    /// </summary>
    public List<DishDTO> Dishes { get; set; } = [];

    /// <summary>
    /// Map the applicable Entity properties to the DTO object.
    /// Note - this logic can be replaced by using the Automapper Nuget package
    /// </summary>
    /// <param name="restaurant"></param>
    /// <returns></returns>
    public static RestaurantDTO? FromEntity(Restaurant? restaurant)
    {
        return restaurant is null
            ? null
            : new RestaurantDTO
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Category = restaurant.Category,
                City = restaurant.Address?.City,
                State = restaurant.Address?.State,
                Street = restaurant.Address?.Street,
                PostalCode = restaurant.Address?.PostalCode,
                CountryCode = restaurant.Address?.CountryCode,
                Dishes = restaurant.Dishes.Select(DishDTO.FromEntity).ToList()
            };
    }

    public static Restaurant ToEntity(RestaurantDTO dto)
    {
        return new Restaurant
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Category = dto.Category,
            Address = new Address
            {
                City = dto.City,
                State = dto.State,
                Street = dto.Street,
                PostalCode = dto.PostalCode,
                CountryCode = dto.CountryCode
            }
        }
}
