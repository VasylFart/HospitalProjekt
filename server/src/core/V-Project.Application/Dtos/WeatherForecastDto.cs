using System.Text.Json.Serialization;

namespace V_Project.Application;

public class WeatherForecastDto
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string? Summary { get; set; }
}