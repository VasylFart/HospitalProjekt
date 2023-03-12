using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V_Project.Domain;

namespace V_Project.Infrastructure;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasMany(r => r.Patients)
                .WithMany(p => p.Rooms)
                 .UsingEntity<PatientRoom>(
            r => r.HasOne(wit => wit.Patient)
                   .WithMany()
                    .HasForeignKey(wit => wit.PatientId),

            p => p.HasOne(wit => wit.Room)
                   .WithMany()
                    .HasForeignKey(wit => wit.RoomId)
            );
    }
}
