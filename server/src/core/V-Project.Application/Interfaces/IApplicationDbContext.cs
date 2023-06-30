using Microsoft.EntityFrameworkCore;
using V_Project.Domain;

namespace V_Project.Application;

public interface IApplicationDbContext : IDisposable
{
    DbSet<Patient> Patients { get; }

    DbSet<Center> Centers { get; }

    DbSet<Address> Addresses { get; }

    DbSet<Comment> Comments { get; }

    DbSet<Contact> Contacts { get; }

    DbSet<Doctor> Doctors { get; }

    DbSet<PatientRoom> PatientRooms { get; }

    DbSet<Room> Rooms { get; }

    DbSet<Department> Depatments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}