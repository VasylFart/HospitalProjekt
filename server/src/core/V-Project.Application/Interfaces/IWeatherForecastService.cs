using V_Project.Application;

namespace V_Project.Application;

public interface IWeatherForecastService
{
    public IEnumerable<WeatherForecastDto> GetWeatherForecast();
}