using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace V_Project.Application;

public class PostPatientDto
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Pesel { get; set; }
    public string? Citi { get; set; }
    public string Kontakt { get; set; }

    [Phone]
    public string MobilePhone { get; set; }
}
