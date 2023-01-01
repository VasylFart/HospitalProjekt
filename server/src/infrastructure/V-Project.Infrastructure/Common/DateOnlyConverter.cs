using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace V_Project.Infrastructure;

public sealed class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
        d => d.ToDateTime(TimeOnly.MinValue),
        d => DateOnly.FromDateTime(d))
    {
    }
}