using System.ComponentModel.DataAnnotations;

namespace V_Project.Application;

public class PatientDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Pesel { get; set; }
    public string? Citi { get; set; }
    public string Kontakt { get; set; }
    
    [Phone]
    public string MobilePhone { get; set; }
}
