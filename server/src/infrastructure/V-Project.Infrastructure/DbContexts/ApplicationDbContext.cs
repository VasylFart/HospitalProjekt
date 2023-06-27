using System.Reflection;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using V_Project.Application;
using V_Project.Domain;

namespace V_Project.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(
        DbContextOptions options) : base(options)
    {
    }

    // The DbSet property will tell EF Core tha we have a table that needs to be created
    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Center> Centers => Set<Center>();

    public DbSet<Address> Addresses  => Set<Address>();

    public DbSet<Comment> Comments => Set<Comment>();

    public DbSet<Contact> Contacts => Set<Contact>();

    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<PatientRoom> PatientRooms => Set<PatientRoom>();
        
    public DbSet<Room> Rooms => Set<Room>();

    public DbSet<Status> Statuses => Set<Status>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseExceptionProcessor();
        optionsBuilder.EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter, DateOnlyComparer>()
            .HaveColumnType("date");
    }
}