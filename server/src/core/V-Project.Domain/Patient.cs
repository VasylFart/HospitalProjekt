namespace V_Project.Domain;

public class Patient
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string Pesel { get; set; }

    public Address Address { get; set; }

    public Contact? Contact { get; set; }

    public Status Status { get; set; }

    public int StatusId { get; set; }

    public List<Room> Rooms { get; set; }

    public Doctor Doctor { get; set; }

    public Guid DoctorId { get; set; }

    public List<Comment> Comments { get; set; }

    public Statistic Statistic { get; set; }

    public int StatisticId { get; set; }

    public Center Center { get; set; }

    public int CenterId { get; set; }
}
