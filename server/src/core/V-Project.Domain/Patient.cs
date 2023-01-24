namespace V_Project.Domain;

public class Patient
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Pesel { get; set; }
    public string? City { get; set; }
    public string? Contact { get; set; }
    public string? MobilePhone { get; set; }
}
