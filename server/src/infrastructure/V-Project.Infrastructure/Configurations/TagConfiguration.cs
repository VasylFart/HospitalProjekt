using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V_Project.Domain;

namespace V_Project.Infrastructure;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasData( new Tag() { Id = 1, Value = "Yellow" },
            new Tag() { Id = 2, Value = "Orange" },
            new Tag() { Id = 3, Value = "Green" });
    }
}
