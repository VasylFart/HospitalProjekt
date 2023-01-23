namespace V_Project.Application;

public class PostPatientDto
{
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Pesel { get; set; }
    public string? City { get; set; }
    public string? Contact { get; set; }
    public string? MobilePhone { get; set; }
}
