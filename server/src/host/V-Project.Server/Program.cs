using Microsoft.EntityFrameworkCore;
using Serilog;
using V_Project.Infrastructure;

namespace V_Project.Server;

public class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = TopLevelLogger.CreateLogger();

        try
        {
            Log.Information("Starting up");
            var host = CreateHostBuilder(args).Build();

            MigrateDb(host);

            await host.RunAsync();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application start-up failed");

            throw;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }

    private static void MigrateDb(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApplicationDbContext>();

        if (context.Database.IsSqlServer()) context.Database.Migrate();

        //if (context.Database.IsInMemory()) DbContextSeed.Seed(services.GetRequiredService<ApplicationDbContext>());
    }
}