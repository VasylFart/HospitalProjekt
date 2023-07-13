namespace V_Project.Domain;

public class Room
{
    public int Id { get; set; }

    public int Number { get; set; }
    
    public List<Patient> Patients { get; set; }
}