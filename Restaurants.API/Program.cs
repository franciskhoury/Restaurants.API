using Restaurants.API.Middleware;
using Restaurants.Application.Extensions;
using Restaurants.Application.Services;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Services;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

using Serilog;

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

builder.Services.AddOpenApi();

builder.Services.AddScoped<ExceptionHandlingMiddleware>();

builder.Host.UseSerilog((context, configuration) =>
    configuration
    .ReadFrom.Configuration(context.Configuration)
    //.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    //.MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
    //.WriteTo.File("Logs/Restaurant-API-.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
    //.WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine}{Message:lj}{NewLine}{Exception}")
    );

var app = builder.Build();


var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.SeedAsync();



// Configure the HTTP request pipeline. (MIDDLEWARE)
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    _ = app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
