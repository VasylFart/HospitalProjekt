namespace V_Project.Domain;

public class Patient
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string Pesel { get; set; }

    public Address Address { get; set; }

    public Contact? Contact { get; set; }

    public Department Department { get; set; }

    public int DepartmentId { get; set; }

    public List<Room> Rooms { get; set; }

    public Doctor Doctor { get; set; }

    public Guid DoctorId { get; set; }

    public List<Comment> Comments { get; set; }

    public Center Center { get; set; }

    public int CenterId { get; set; }
}
