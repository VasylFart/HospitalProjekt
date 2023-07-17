
namespace V_Project.Application;
public class PatientDto
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public int Age => DateOfBirth.CountAge();

    public string Pesel { get; set; }
}
    