namespace V_Project.Domain;

public class Comment
{
    public int Id { get; set; }

    public string Message { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public Doctor Doctor { get; set; }

    public Guid DoctorId { get; set; }

    public Patient Patient { get; set; }

    public Guid PatientId { get; set; }
}
