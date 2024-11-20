using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Commands;
public class UpdateRestaurantCommandHandler(IRestaurantRepository restaurantRepository,
                                 ILogger<UpdateRestaurantCommandHandler> logger,
                                 IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating restaurant with id: {request.Id}");
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);

        if (restaurant == null)
            return false;

        _ = mapper.Map(request, restaurant);
        await restaurantRepository.SaveChanges();
        return true;
    }
}
