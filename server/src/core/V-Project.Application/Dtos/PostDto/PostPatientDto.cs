using V_Project.Domain;

namespace V_Project.Application;

public class PostPatientDto
{
    public string FullName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string Pesel { get; set; }

    public PostAddressDto Address { get; set; }

    public PostContactDto Contact { get; set; }

    public PostCommentDto Comment { get; set; }

    public string DoctorId { get; set; }

    public string DepartmentId { get; set; }

    public string RoomId { get; set; }
}
