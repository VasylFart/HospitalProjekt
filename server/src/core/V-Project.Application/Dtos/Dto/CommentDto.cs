namespace V_Project.Application;

public class CommentDto
{
    public int Id { get; set; }

    public string Message { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DoctorDto Doctor { get; set; }

    public PatientDto Patient { get; set; }
}
