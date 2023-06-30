using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V_Project.Domain;

namespace V_Project.Infrastructure;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasOne(p => p.Address)
                .WithOne(a => a.Patient)
                 .HasForeignKey<Address>(a => a.PatientId)
                  .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Contact)
                .WithOne(c => c.Patient)
                 .HasForeignKey<Contact>(a => a.PatientId)
                  .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Department)
                .WithMany(t => t.Patients)
                 .HasForeignKey(t => t.DepartmentId)
                  .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.Comments)
                    .WithOne(p => p.Patient)
                     .HasForeignKey(p => p.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);
    }
}
