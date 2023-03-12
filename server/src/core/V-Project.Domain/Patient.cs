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

    public Room Room { get; set; }

}
