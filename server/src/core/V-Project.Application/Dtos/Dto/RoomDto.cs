namespace V_Project.Application;

public class RoomDto
{
    public int Id { get; set; }

    public int Number { get; set; }

    public List<PatientDto> Patients { get; set; }
}
