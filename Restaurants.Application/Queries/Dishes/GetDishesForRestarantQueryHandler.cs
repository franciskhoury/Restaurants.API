using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Application.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Queries.Dishes;
public class GetDishesForRestarantQueryHandler(ILogger<GetDishesForRestarantQueryHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDTO>>
{
    public async Task<IEnumerable<DishDTO>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting all dishes for restaurant with id: {request.RestaurantId}.");
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);

        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var results = mapper.Map<IEnumerable<DishDTO>>(restaurant.Dishes);
        return results;
    }

    //Task<IEnumerable<DishDTO>> IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDTO>>.Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}
}
