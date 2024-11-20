﻿using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Commands;
public class CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository,
                                 ILogger<CreateRestaurantCommandHandler> logger,
                                 IMapper mapper) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new restaurant.");
        var restaurant = mapper.Map<Restaurant>(request);
        int id = await restaurantRepository.CreateAsync(restaurant);

        return id;
    }
}