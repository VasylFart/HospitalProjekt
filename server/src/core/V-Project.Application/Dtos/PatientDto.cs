using System.ComponentModel.DataAnnotations;

namespace V_Project.Application;

public class PatientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get => DateTime.Now.Year - DateOfBirth.Year; }
    public DateOnly DateOfBirth { get; set; }
    public string Pesel { get; set; }
    public string? City { get; set; }
    public string? Contact { get; set; }
    public string? MobilePhone { get; set; }
}
