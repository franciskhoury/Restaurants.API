
using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Application.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Queries.Restaurants;
public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDTO>
{
    public async Task<RestaurantDTO> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting restaurant with id {RestaurantId}", request.Id);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        // Old approach, "manual" mapping
        //var restaurantDTO = RestaurantDTO.FromEntity(restaurant);

        // New approach using Automapper
        var restaurantDTO = mapper.Map<RestaurantDTO>(restaurant);

        return restaurantDTO;
    }
}
