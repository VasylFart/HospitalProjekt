namespace V_Project.Domain;

public class PatientRoom
{
    public Patient Patient { get; set; }

    public Guid PatientId { get; set; }

    public Room Room { get; set; }

    public int RoomId { get; set; }
}
