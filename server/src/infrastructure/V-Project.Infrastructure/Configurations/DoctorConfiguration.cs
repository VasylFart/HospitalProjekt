using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V_Project.Domain;

namespace V_Project.Infrastructure;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasMany(d => d.Comments)
                .WithOne(c => c.Doctor)
                 .HasForeignKey(c => c.DoctorId);

        builder.HasMany(d => d.Patients)
                .WithOne(p => p.Doctor)
                 .HasForeignKey(p => p.DoctorId);
    }
}
