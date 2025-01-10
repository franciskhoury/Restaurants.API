using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Commands.Restaurants;
public class UpdateRestaurantCommandHandler(IRestaurantRepository restaurantRepository,
                                 ILogger<UpdateRestaurantCommandHandler> logger,
                                 IMapper mapper) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id {RestaurantId} with {@UpdatedRestaurant}", request.Id, request);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);

        if (restaurant == null)
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        _ = mapper.Map(request, restaurant);
        await restaurantRepository.SaveChanges();
    }
}
