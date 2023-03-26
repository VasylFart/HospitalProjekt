using V_Project.Domain;

namespace V_Project.Application;

public class PostAddressDto
{
    public string Country { get; set; }

    public string? City { get; set; }

    public string Street { get; set; }

    public int NumberHome { get; set; }

    public Guid PatientId { get; set; }
}