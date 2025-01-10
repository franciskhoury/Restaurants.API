using MediatR;

using Restaurants.Application.DTOs;

namespace Restaurants.Application.Queries.Restaurants;
public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDTO>>
{
}
