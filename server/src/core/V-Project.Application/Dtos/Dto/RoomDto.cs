using V_Project.Domain;

namespace V_Project.Application;

public class RoomDto
{
    public int Id { get; set; }

    public int Number { get; set; }

    public List<Patient> Patients { get; set; }
}
