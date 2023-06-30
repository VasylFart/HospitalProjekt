using V_Project.Domain;

namespace V_Project.Application;
public class PatientDto
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public int Age => DateOfBirth.CountAge();

    public DateOnly DateOfBirth { get; set; }

    public string Pesel { get; set; }

    public AddressDto Address { get; set; }

    public ContactDto? Contact { get; set; }

    public List<DepartmentDto> Statuses { get; set; }

    public List<RoomDto> Rooms { get; set; }

    public DoctorDto Doctor { get; set; }

    public List<CommentDto> Comments { get; set; }

    public CenterDto Center { get; set; }
}
