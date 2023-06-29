namespace V_Project.Application;

public class StatisticDto
{
    public int Id { get; set; }

    public List<DoctorDto> Doctors { get; set; }

    public List<PatientDto> Patients { get; set; }

    public List<StatusDto> Statuss { get; set; }

    public List<RoomDto> Rooms { get; set; }
}
