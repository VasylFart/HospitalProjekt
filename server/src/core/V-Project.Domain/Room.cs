namespace V_Project.Domain;

public class Room
{
    public Guid Id { get; set; }

    public int Number { get; set; }
    
    public List<Patient> Patients { get; set; }

    public Department Department { get; set; }

    public Guid DepartmentId { get; set; }
}