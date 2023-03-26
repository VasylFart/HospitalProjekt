using V_Project.Domain;

namespace V_Project.Application;

public class PostDoctorDto
{
    public string FullName { get; set; }

    public List<Patient> Patients { get; set; }

    public List<Comment> Comments { get; set; }

    public Guid CenterId { get; set; }
}
