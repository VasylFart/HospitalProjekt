using System.Text.Json.Serialization;

namespace V_Project.Application;

public class PersonDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Country { get; set; }
}
