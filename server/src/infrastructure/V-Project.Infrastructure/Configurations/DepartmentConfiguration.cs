using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V_Project.Domain;

namespace V_Project.Infrastructure;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasMany(r => r.Rooms)
                .WithOne(d => d.Department)
                 .HasForeignKey(d => d.DepartmentId)
                  .OnDelete(DeleteBehavior.Restrict);
    }
}
