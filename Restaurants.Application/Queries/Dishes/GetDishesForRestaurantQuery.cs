using MediatR;

using Restaurants.Application.DTOs;

namespace Restaurants.Application.Queries.Dishes;
public class GetDishesForRestaurantQuery(int restaurantId) : IRequest<IEnumerable<DishDTO>>
{
    public int RestaurantId { get; } = restaurantId;
}
