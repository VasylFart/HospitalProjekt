﻿using V_Project.Domain;

namespace V_Project.Application;

public class CommentService : ICommentService
{
    private readonly IApplicationDbContext dbContext;

        public CommentService(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

    public IEnumerable<CommentDto> GetComment()
    {
        var result = dbContext.Comments.ToList();

        return result.Select(c => new CommentDto
        {
            Id = c.Id,
            Message = c.Message,
            UpdatedDate = c.UpdatedDate ?? c.CreatedDate
        });
    }

    public CommentDto UpdateComment(PostCommentDto commentDto, Guid id)
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
