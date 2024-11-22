using Restaurants.Application.Extensions;
using Restaurants.Application.Services;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Services;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register services for the Infrastucture layer
builder.Services.AddInfrastructure(builder.Configuration);

// Allow for 'Async'-named methods in Controllers
builder.Services.AddControllersWithViews(options => options.SuppressAsyncSuffixInActionNames = false);

// Register services for the Infrastucture layer
builder.Services.AddApplication();

// Inject service, repo for validating restaurant catgories
builder.Services.AddScoped<IRestaurantCategoryService, RestaurantCategoryService>();
builder.Services.AddScoped<IRestaurantCategoryRepository, RestaurantCategoryRepository>();

var app = builder.Build();


var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.SeedAsync();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
