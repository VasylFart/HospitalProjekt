namespace V_Project.Domain;

public class Statistic
{
    public int Id { get; set; }

    public List<Doctor> Doctors { get; set;}

    public List<Patient> Patients { get; set;}

    public List<Department> Statuses { get; set;}

    public List<Room> Rooms { get; set;}
}
