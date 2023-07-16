namespace V_Project.Domain;

public class Department
{
    public Guid Id { get; set; }

    public string Value { get; set; }

    public List<Patient> Patients { get; set; }

    public List<Room> Rooms { get; set; }

    public Doctor Doctor { get; set; }
}
