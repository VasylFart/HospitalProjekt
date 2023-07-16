namespace V_Project.Domain;

public class Room
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public int Capacity { get; set; }

    public int OccupiedSlots { get; set; }

    public int FreeSlots => Capacity - OccupiedSlots;

    public List<Patient> Patients { get; set; }

    public Department Department { get; set; }

    public Guid DepartmentId { get; set; }
}