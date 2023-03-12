namespace V_Project.Domain;

public class Patient
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string Pesel { get; set; }


    public Address Address { get; set; }

    public Contact? Contact { get; set; }

    public List<Tag> Tags { get; set; }

    public List<Room> Rooms { get; set; }

    public Doctor Doctor { get; set; }

    public Guid DoctorId { get; set; }

    public List<Comment> Comments { get; set; }
}
