using System.Text.Json.Serialization;

namespace V_Project.Application;

public class PostPatientDto
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Country { get; set; }
}
