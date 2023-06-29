using V_Project.Domain;

namespace V_Project.Application;

public class CommentService : ICommentService
{
    private readonly IApplicationDbContext dbContext;

        public CommentService(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

    public CommentDto AddNewComment(PostCommentDto newPostCommentDto)
    {
        var newComment = new Comment()
        {
            Message = newPostCommentDto.Message,
            CreatedDate= newPostCommentDto.CreatedDate
        };

        dbContext.Comments.Add(newComment);
        dbContext.SaveChangesAsync();

        return new CommentDto
        {
            Id = newComment.Id,
            Message = newComment.Message,
            CreatedDate = newComment.CreatedDate
        };
    }

    public void DeleteComment(int id)
    {
        var comment = dbContext.Comments.FirstOrDefault(c => c.Id == id);

        if (comment == null)
        {
            throw new ClientException($"Comment with Id: {id} doesn`t exist.");
        }

        dbContext.Comments.Remove(comment);
        dbContext.SaveChangesAsync();
    }

    public IEnumerable<CommentDto> GetComment()
    {
        var result = dbContext.Comments.ToList();

        return result.Select(c => new CommentDto
        {
            Id = c.Id,
            Message = c.Message,
            CreatedDate = c.CreatedDate
        });
    }

    public CommentDto UpdateComment(PostCommentDto commentDto, int id)
    {
        var comment = dbContext.Comments.FirstOrDefault(c => c.Id == id);

        if (comment == null)
        {
            throw new ClientException($"Comment with Id: {id} doesn`t exist.");
        }

        if (comment != null)
        {
            comment.Message = commentDto.Message;

            dbContext.Comments.Update(comment);
            dbContext.SaveChangesAsync();
        }

        var updatedComment = dbContext.Comments.FirstOrDefault(c => c.Id == id);

        if (updatedComment == null)
        {
            throw new Exception();
        }

        return new CommentDto
        {
            Id = updatedComment.Id,
            Message = updatedComment.Message,
            UpdatedDate = updatedComment.UpdatedDate
        };
    }
}
