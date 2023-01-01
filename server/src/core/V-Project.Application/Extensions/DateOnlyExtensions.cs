using System.Globalization;

namespace V_Project.Application;

public static class DateOnlyExtensions
{
    public static string ToIsoString(this DateOnly date)
    {
        return date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    }
}