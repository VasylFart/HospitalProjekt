namespace V_Project.Application;

public class CenterDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<PatientDto> Patients { get; set; }

    public List<DoctorDto> Doctors { get; set; }
}
