namespace Restaurants.API.Interfaces;

public interface IWeatherForecastRequest
{
    int MaxTempC { get; set; }
    int MinTempC { get; set; }
}