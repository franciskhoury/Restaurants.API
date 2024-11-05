﻿using AutoMapper;

using Restaurants.Domain.Entities;

namespace Restaurants.Application.DTOs;

/// <summary>
/// Map Restauant entity to RestaurantDTO
/// </summary>
public class RestaurantProfile : Profile
{
    /// <summary>
    ///     /// <summary>
    /// Constructor - set up mapping entity to DTO
    /// </summary>
    /// </summary>
    public RestaurantProfile()
    {
        _ = CreateMap<Restaurant, RestaurantDTO>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(d => d.State, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.State))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d => d.CountryCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.CountryCode))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));
    }
}