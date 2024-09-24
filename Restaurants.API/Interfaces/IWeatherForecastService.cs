namespace Restaurants.API.Interfaces;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> Get();

    IEnumerable<WeatherForecast> Get(int minT, int maxT, int numResults);
}