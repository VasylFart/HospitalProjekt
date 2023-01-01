using V_Project.Domain;
using Microsoft.EntityFrameworkCore;
using V_Project.Infrastructure;

namespace V_Project.Sql;

public static class DbContextSeed
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public static void Seed(ApplicationDbContext context)
    {
        if (!context.Database.IsInMemory()) throw new Exception("Not InMemory Db. Cannot seed.");
        // Seed, if necessary

        if (!context.WeatherForecasts.Any())
        {
            context.WeatherForecasts.AddRange(
                new WeatherForecast
                {
                    Date = new DateOnly(2022,12,24),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                },
                new WeatherForecast
                {
                    Date = new DateOnly(2022, 12, 25),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                },
                new WeatherForecast
                {
                    Date = new DateOnly(2022, 12, 26),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                },
                new WeatherForecast
                {
                    Date = new DateOnly(2022, 12, 27),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                },
                new WeatherForecast
                {
                    Date = new DateOnly(2022, 12, 28),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                },
                new WeatherForecast
                {
                    Date = new DateOnly(2022, 12, 29),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                });

            context.SaveChanges();
        }
    }
}