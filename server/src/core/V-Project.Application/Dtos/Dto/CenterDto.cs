using V_Project.Domain;

namespace V_Project.Application;

public class CenterDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Address Address { get; set; }
}
