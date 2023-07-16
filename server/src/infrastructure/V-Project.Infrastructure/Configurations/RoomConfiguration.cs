using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V_Project.Domain;

namespace V_Project.Infrastructure;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasMany(d => d.Patients)
                .WithOne(p => p.Room)
                 .HasForeignKey(p => p.RoomId)
                  .OnDelete(DeleteBehavior.Restrict);
    }
}
