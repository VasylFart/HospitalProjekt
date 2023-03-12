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
    }
}