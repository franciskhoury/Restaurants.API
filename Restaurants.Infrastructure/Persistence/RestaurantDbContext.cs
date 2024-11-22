using Microsoft.EntityFrameworkCore;

using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence;

public class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : DbContext(options)
{
    internal DbSet<Restaurant> Restaurant { get; set; }
    internal DbSet<Dish> Dish { get; set; }
    internal DbSet<RestaurantCategory> RestaurantCategory { get; set; }


    /// <summary>
    /// Set up the entity relationships
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Address attributes belong to the Restaurant table (1 : 1)
        _ = modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);

        // Dish attributes belong to the Restaurant table (1 : many)
        _ = modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
            .WithOne()                      // each Dish belongs to one Restaurant
            .HasForeignKey(d => d.RestaurantId);
    }
}
