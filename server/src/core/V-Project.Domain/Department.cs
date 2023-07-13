namespace V_Project.Domain;

public class Department
{
    public int Id { get; set; }

    public string Value { get; set; }

    public List<Patient> Patients { get; set; }
}
