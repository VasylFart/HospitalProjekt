using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V_Project.Domain;

namespace V_Project.Infrastructure;

public class CenterConfiguration : IEntityTypeConfiguration<Center>
{
    public void Configure(EntityTypeBuilder<Center> builder)
    {
        builder.HasData(new Center() { Id = 1, Name = "Szpital" });

        builder.HasMany(c => c.Patients)
                .WithOne(p => p.Center)
                 .HasForeignKey(p => p.CenterId);

        builder.HasMany(c => c.Doctors)
                .WithOne(p => p.Center)
                 .HasForeignKey(p => p.CenterId);
    }
}
