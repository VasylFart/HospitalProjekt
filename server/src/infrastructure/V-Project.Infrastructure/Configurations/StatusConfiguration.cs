using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V_Project.Domain;

namespace V_Project.Infrastructure;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasData( new Status() { Id = 1, Value = "Yellow" },
            new Status() { Id = 2, Value = "Orange" },
            new Status() { Id = 3, Value = "Green" });
    }
}
