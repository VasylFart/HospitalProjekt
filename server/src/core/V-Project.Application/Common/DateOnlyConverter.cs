using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace V_Project.Application;

public sealed class DateOnlyConverter : JsonConverter<DateOnly>
{
    private static readonly string[] formats = new string[] {
        "yyyy-MM-dd",
        "yyyy-MM",
        "yyyy"
    };

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? s = reader.GetString();
        if (s is null)
            return DateOnly.MinValue;

        string datePart = s[0..Math.Min(10, s.Length)];

        if (!DateOnly.TryParseExact(datePart, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly date))
            throw new JsonException($"Invalid date format. Valid formats: {string.Join(", ", formats)}");

        return date;
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, 
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToIsoString());
    }
}