namespace V_Project.Application;

public class StatusDto
{
    public int Id { get; set; }

    public string Value { get; set; }

    public PatientDto Patient { get; set; }
}
