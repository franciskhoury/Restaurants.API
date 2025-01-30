﻿using MediatR;

using Restaurants.Application.DTOs;

namespace Restaurants.Application.Queries.Dishes;
public class GetDishByIdForRestaurantQuery(int restaurantId, int dishId) : IRequest<DishDTO>
{
    public int RestaurantId { get; } = restaurantId;
    public int DishId { get; } = dishId;
}
