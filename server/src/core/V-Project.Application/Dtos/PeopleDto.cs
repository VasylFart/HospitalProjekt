using System.Text.Json.Serialization;

namespace V_Project.Application;

public class PeopleDto
{
    [JsonConverter(typeof(DateOnlyConverter))]
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Country { get; set; }
}
