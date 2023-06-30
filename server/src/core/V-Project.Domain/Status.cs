namespace V_Project.Domain;

public class Status
{
    public int Id { get; set; }

    public string Value { get; set; }

    public List<Patient> Patients { get; set; }

    public Guid PatientId { get; set; }
}
