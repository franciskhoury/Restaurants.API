using Restaurants.API.Interfaces;
namespace Restaurants.API.Models;

/// <summary>
/// Weather Forecaset Request parameters
/// </summary>
public class WeatherForecastRequest : IWeatherForecastRequest
{
    /// <inheritdoc/>
    public int MaxTempC { get; set; }
    /// <inheritdoc/>
    public int MinTempC { get; set; }
}
