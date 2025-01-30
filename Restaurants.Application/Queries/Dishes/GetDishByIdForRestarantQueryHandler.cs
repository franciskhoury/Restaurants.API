using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Application.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Queries.Dishes;
public class GetDishByIdForRestarantQueryHandler(ILogger<GetDishByIdForRestarantQueryHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDTO>
{
    public async Task<DishDTO> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting dish with id: {request.DishId} for restaurant with id: {request.RestaurantId}.");
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
        if (dish == null) throw new NotFoundException(nameof(Dish), request.DishId.ToString());

        var result = mapper.Map<DishDTO>(dish);

        return result;
    }

}
