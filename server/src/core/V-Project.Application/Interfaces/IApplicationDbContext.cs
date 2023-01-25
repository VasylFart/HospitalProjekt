using Microsoft.EntityFrameworkCore;
using V_Project.Domain;

namespace V_Project.Application;

public interface IApplicationDbContext : IDisposable
{
    DbSet<WeatherForecast> WeatherForecasts { get; }

    DbSet<Patient> Patients { get; }

    DbSet<Center> Centers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}