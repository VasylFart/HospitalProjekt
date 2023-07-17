namespace V_Project.Application;

public interface ICommentService
{
    public IEnumerable<CommentDto> GetComment();

    public CommentDto UpdateComment(PostCommentDto commentDto, Guid id);
}
