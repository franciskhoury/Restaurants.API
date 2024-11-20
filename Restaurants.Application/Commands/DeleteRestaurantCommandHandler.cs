using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Commands;
public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantRepository restaurantRepo) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting restaurant with id: {request.Id}");
        var restaurant = await restaurantRepo.GetByIdAsync(request.Id);

        if (restaurant == null)
            return false;

        await restaurantRepo.Delete(restaurant);
        return true;

    }
}
