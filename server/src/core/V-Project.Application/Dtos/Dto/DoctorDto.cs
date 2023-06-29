using V_Project.Domain;

namespace V_Project.Application;

public class DoctorDto
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public List<PatientDto> Patients { get; set; }

    public CenterDto Center { get; set; }
}
