using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V_Project.Domain;

namespace V_Project.Infrastructure;

public class StatisticConfiguration : IEntityTypeConfiguration<Statistic>
{
    public void Configure(EntityTypeBuilder<Statistic> builder)
    {
        builder.HasMany(s => s.Doctors)
                .WithOne(d => d.Statistic)
                 .HasForeignKey(d => d.StatisticId)
                  .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Patients)
                .WithOne(p => p.Statistic)
                 .HasForeignKey(p => p.StatisticId)
                  .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Rooms)
                .WithOne(r => r.Statistic)
                 .HasForeignKey(r => r.StatisticId)
                  .OnDelete(DeleteBehavior.Restrict);
    }
}
