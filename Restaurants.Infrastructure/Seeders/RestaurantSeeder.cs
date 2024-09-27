using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;
internal class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantSeeder
{
    public async Task SeedAsync()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurant.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurant.AddRange(restaurants);
                _ = await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new()
            {
                Name = "Testaurant",
                Category = "Imaginary Food",
                Description = "A test restaurant set up through data seeding from the Restaurants.API application.",
                ContactEmail = "AllDayChef@testaurant.com",
                ContactPhoneNumber = "867-5309",
                HasDelivery = true,
                Address = new ()
                {
                   Street = "45 Hazel Street",
                   City = "Paterson",
                   State = "NJ",
                   PostalCode = "07777",
                   CountryCode = "US"
                },
                Dishes = [
                    new ()
                    {
                        Name = "Big Fred's Beef and Barf",
                        Description = "We're not exactly sure what's in it, but sometimes it's great, and sometimes it sucks.",
                        Price = 12.99M
                    },
                    new ()
                    {
                        Name = "Chicken Claw Nuggets",
                        Description = "Fried bits that taste like chicken, if you can bite through them.",
                        Price = 8.99M,
                        Calories = 200
                    }
                ]
            },
        new()
        {
            Name = "Slider Hell",
            Category = "Imaginary Food",
            Description = "A test restaurant set up through data seeding from the Restaurants.API application.",
            ContactEmail = "satan@sliders.com",
            ContactPhoneNumber = "666-1234",
            HasDelivery = false,
            Address = new()
            {
                Street = "101 Castle Way",
                City = "Linden",
                State = "NJ",
                PostalCode = "08120",
                CountryCode = "US"
            },
            Dishes =
            [
                    new ()
                    {
                        Name = "Sack o' Suds",
                        Description = "No sliders, just a dripping bag of dishwater with some fries.",
                        Price = 800.99M,
                        Calories=25
                    }
            ]
        }
        ];

        return restaurants;
    }
}
