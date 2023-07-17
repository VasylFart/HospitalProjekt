namespace V_Project.Domain;

public class Doctor
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public List<Patient> Patients { get; set; }

    public Department Department { get; set; }

    public Guid DepartmetId { get; set; }
}
