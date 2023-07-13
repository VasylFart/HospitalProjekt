namespace V_Project.Application;

public class CommentDto
{
    public Guid Id { get; set; }

    public string Message { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
