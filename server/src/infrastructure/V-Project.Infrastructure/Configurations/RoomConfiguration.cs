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
            r => r.HasOne(pr => pr.Patient)
                   .WithMany()
                    .HasForeignKey(pr => pr.PatientId)
                     .OnDelete(DeleteBehavior.Restrict),

            p => p.HasOne(pr => pr.Room)
                   .WithMany()
                    .HasForeignKey(pr => pr.RoomId)
                     .OnDelete(DeleteBehavior.Restrict),
            pr =>
            {
                pr.HasKey(x => new { x.PatientId, x.RoomId });

                pr.Property(x => x.PublicationDate).HasDefaultValueSql("getutcdate()");
            }
        );
    }
}
