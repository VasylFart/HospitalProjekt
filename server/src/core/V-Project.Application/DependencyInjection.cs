using Microsoft.Extensions.DependencyInjection;

namespace V_Project.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastService, WeatherForecastService>();

        services.AddScoped<IPatientService, PatientService>();

        return services;
    }
}