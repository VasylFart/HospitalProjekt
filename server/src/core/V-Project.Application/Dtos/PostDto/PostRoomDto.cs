using V_Project.Domain;

namespace V_Project.Application;

public class PostRoomDto
{
    public int Number { get; set; }

    public List<Patient> Patients { get; set; }
}
