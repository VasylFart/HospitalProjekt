namespace V_Project.Application;

public class AddressDto
{
    public Guid Id { get; set; }

    public string Country { get; set; }

    public string? City { get; set; }

    public string Street { get; set; }

    public int NumberHome { get; set; }
}
