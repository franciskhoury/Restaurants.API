using Microsoft.AspNetCore.Mvc;

using Restaurants.API.Interfaces;
using Restaurants.API.Models;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        var result = _weatherForecastService.Get();
        return result;
    }

    [HttpGet("dayOne")]
    public IActionResult GetDay1()
    {
        var result = _weatherForecastService.Get().First();
        //Response.StatusCode = 400;
        return Ok(result);
    }

    [HttpPost("generate")]
    public IActionResult Generate([FromBody] WeatherForecastRequest wxData, [FromQuery] int numResults)
    {
        try
        {
            if (wxData.MaxTempC < wxData.MinTempC || numResults < 1)
                return BadRequest();
        }
        catch (Exception)
        {
            return BadRequest();
        }

        var result = _weatherForecastService.Get(wxData.MinTempC, wxData.MaxTempC, numResults);
        return Ok(result);


    }

    [HttpPost("hello")]
    public string SayHello([FromBody] string name)
    {
        return $"Hello, {name}!";
    }
}
