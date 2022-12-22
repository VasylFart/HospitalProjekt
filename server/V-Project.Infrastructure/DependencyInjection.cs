using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using V_Project.Application;

namespace V_Project.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlDatabaseOptions = GetSqlDatabaseOptions(services, configuration);

        services.AddDbContext(
            configuration.GetValue<bool>("UseInMemoryDatabase"),
            sqlDatabaseOptions);

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }

    private static void AddDbContext(
        this IServiceCollection services,
        bool isInMemory,
        SqlDatabaseOptions sqlDatabaseOptions)
    {
        if (isInMemory)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("VProjectLocalDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(sqlDatabaseOptions.ConnectionString,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
    }

    private static SqlDatabaseOptions GetSqlDatabaseOptions(IServiceCollection services, IConfiguration configuration)
    {
        var sqlDatabaseSection = configuration.GetSection(SqlDatabaseOptions.Position);
        services.Configure<SqlDatabaseOptions>(sqlDatabaseSection);
        var sqlDatabaseOptions = services.BuildServiceProvider()
                                     .GetService<IOptions<SqlDatabaseOptions>>()?.Value ??
                                 throw new InvalidOperationException("SqlDatabase section not configured");
        return sqlDatabaseOptions;
    }
}