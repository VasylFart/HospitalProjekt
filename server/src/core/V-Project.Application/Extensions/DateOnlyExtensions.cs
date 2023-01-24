using System.Globalization;

namespace V_Project.Application;

public static class DateOnlyExtensions
{
    public static string ToIsoString(this DateOnly date)
    {
        return date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    }

    public static int CountAge(this DateOnly dateOfBirth)
    {
        if (DateTime.Today.Month < dateOfBirth.Month ||
            DateTime.Today.Month == dateOfBirth.Month &&
            DateTime.Today.Day < dateOfBirth.Day)
        {
            return DateTime.Today.Year - dateOfBirth.Year - 1;
        }
        return DateTime.Today.Year - dateOfBirth.Year;
    }

    internal static DateOnly CountAge()
    {
        throw new NotImplementedException();
    }
}