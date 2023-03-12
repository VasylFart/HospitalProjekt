namespace V_Project.Domain;

public class Contact
{
    public int Id { get; set; }

    public string? MobilePhone { get; set; }

    public string? Email { get; set; }

    public Patient Patient { get; set; }

    public Guid PatientId { get; set; }
}
