namespace V_Project.Application;

public interface ICommentService
{
    public IEnumerable<CommentDto> GetComment();

    public CommentDto AddNewComment(PostCommentDto newPostCommentDto);

    public CommentDto UpdateComment(PostCommentDto commentDto, Guid id);

    public void DeleteComment(Guid id);
}
