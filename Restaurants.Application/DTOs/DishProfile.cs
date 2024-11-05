using AutoMapper;

using Restaurants.Domain.Entities;

namespace Restaurants.Application.DTOs;

/// <summary>
/// /// <summary>
/// Map Dish entity to DishDTO
/// </summary>
public class DishProfile : Profile
{
    /// <summary>
    /// Constructor - set up mapping entity to DTO
    /// </summary>
    public DishProfile()
    {
        _ = CreateMap<Dish, DishDTO>();
    }
}
