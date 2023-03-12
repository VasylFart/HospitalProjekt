using V_Project.Domain;

namespace V_Project.Application;

public class ContactDto
{
    public int Id { get; set; }

    public string? MobilePhone { get; set; }

    public string? Email { get; set; }

    public Patient Patient { get; set; }

    public Guid PatientId { get; set; }
}
