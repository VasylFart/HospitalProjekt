namespace V_Project.Domain;

public class Patient
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string Pesel { get; set; }

    public Address Address { get; set; }

    public Contact Contact { get; set; }

    public Department Department { get; set; }

    public Guid DepartmentId { get; set; }

    public Room Room { get; set; }

    public Guid RoomId { get; set; }

    public Doctor Doctor { get; set; }

    public Guid DoctorId { get; set; }

    public Comment Comment { get; set; }
}
