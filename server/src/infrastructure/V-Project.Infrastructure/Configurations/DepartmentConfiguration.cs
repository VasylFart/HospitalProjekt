using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V_Project.Domain;

namespace V_Project.Infrastructure;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasData( new Department() { Id = 1, Value = "Yellow" },
            new Department() { Id = 2, Value = "Orange" },
            new Department() { Id = 3, Value = "Green" });
    }
}
