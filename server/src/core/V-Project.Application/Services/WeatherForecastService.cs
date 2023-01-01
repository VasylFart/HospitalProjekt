namespace V_Project.Application;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IApplicationDbContext dbContext;

    public WeatherForecastService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<WeatherForecastDto> GetWeatherForecast()
    {
        var result = dbContext.WeatherForecasts
            .ToList();

        return result.Select(x => new WeatherForecastDto
        {
            Date = x.Date,
            Summary = x.Summary,
            TemperatureC = x.TemperatureC,
            TemperatureF = x.TemperatureF
        });
    }
}