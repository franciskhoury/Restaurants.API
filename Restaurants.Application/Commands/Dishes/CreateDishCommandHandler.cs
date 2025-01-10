using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Commands.Dishes;
public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger,
    IRestaurantRepository restaurantReository,
    IDishRepository dishRepository,
    IMapper mapper) : IRequestHandler<CreateDishCommand>
{
    public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new dish: {@DishRequest}", request);
        var restaurant = await restaurantReository.GetByIdAsync(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dish = mapper.Map<Dish>(request);

        _ = await dishRepository.CreateAsync(dish);
    }
}
