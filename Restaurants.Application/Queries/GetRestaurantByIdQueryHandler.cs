
using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Application.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Queries;
public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDTO?>
{
    public async Task<RestaurantDTO> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting restaurant with id = {request.Id}.");
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);

        // Old approach, "manual" mapping
        //var restaurantDTO = RestaurantDTO.FromEntity(restaurant);

        // New approach using Automapper
        var restaurantDTO = mapper.Map<RestaurantDTO>(restaurant);

        return restaurantDTO;
    }
}
