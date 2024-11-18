
using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Application.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Queries;
public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDTO>>
{
    public async Task<IEnumerable<RestaurantDTO>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants.");
        var restaurants = await restaurantRepository.GetAllAsync();

        // Old approach, "manual" mapping
        //var restaurantsDTOs = restaurants.Select(RestaurantDTO.FromEntity);
        var restaurantsDTOs = mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);

        return restaurantsDTOs!;
    }
}
