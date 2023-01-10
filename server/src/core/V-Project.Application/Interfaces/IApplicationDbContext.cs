﻿using Microsoft.EntityFrameworkCore;
using V_Project.Domain;

namespace V_Project.Application;

public interface IApplicationDbContext : IDisposable
{
    DbSet<WeatherForecast> WeatherForecasts { get; }
    DbSet<People> People { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}