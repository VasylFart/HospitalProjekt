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
                 .HasForeignKey<Address>(a => a.PatientId);

        builder.HasOne(p => p.Contact)
                .WithOne(c => c.Patient)
                 .HasForeignKey<Contact>(a => a.PatientId);

        builder.HasMany(p => p.Tags)
                .WithOne(t => t.Patient)
                 .HasForeignKey(t => t.PatientId);

        builder.HasMany(d => d.Comments)
                    .WithOne(p => p.Patient)
                     .HasForeignKey(p => p.PatientId);
    }
}
