using V_Project.Domain;
using Microsoft.EntityFrameworkCore;
using V_Project.Infrastructure;

namespace V_Project.Sql;

public static class DbContextSeed
{
    private static readonly Guid AITypeId = Guid.Parse("cae45a05-8c7e-43a9-bc7e-36dfe8fc9fdf");
    private static readonly Guid AITypeId2 = Guid.Parse("4d57393b-f2d9-408d-80a5-1236ec4a9d1f");

    public static void Seed(ApplicationDbContext context)
    {
        if (!context.Database.IsInMemory()) throw new Exception("Not InMemory Db. Cannot seed.");
        // Seed, if necessary

        //if (!context.AITypes.Any())
        //{
        //    context.AITypes.AddRange(
        //        new AIType() { Id = AITypeId, Name = "ML and sub specialties" },
        //        new AIType() { Id = AITypeId2, Name = "Symbolic" });

        //    context.SaveChanges();
        //}
    }
}