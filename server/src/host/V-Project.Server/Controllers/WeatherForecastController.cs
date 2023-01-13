using Microsoft.AspNetCore.Mvc;
using V_Project.Application;

namespace V_Project.Server;

[ApiController]
[Route("api")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> logger;
    private readonly IWeatherForecastService service;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
    {
        this.logger = logger;
        this.service = service;
    }

    [HttpGet("weather-forecast")]
    public IEnumerable<WeatherForecastDto> GetWeatherForecast()
    {
        logger.LogInformation("Getting Weather Forecast");

        return service.GetWeatherForecast();
    }

    
}