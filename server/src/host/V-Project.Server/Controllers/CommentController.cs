using Microsoft.AspNetCore.Mvc;
using V_Project.Application;

namespace V_Project.Server.Controllers;

[ApiController]
[Route("api")]
public class CommentController : Controller
{
    private readonly ILogger<CommentController> logger;
    private readonly ICommentService service;

    public CommentController(ILogger<CommentController> logger, ICommentService service)
    {
        this.logger = logger;
        this.service = service;
    }

    [HttpGet("comments")]
    public IEnumerable<CommentDto> GetComment()
    {
        logger.LogInformation("Getting Comments");

        return service.GetComment();
    }

    [HttpPut("comments/{id}")]
    public CommentDto Put([FromBody] PostCommentDto commentDto, Guid id)
    {
        logger.LogInformation("Updating Comment");

        return service.UpdateComment(commentDto, id);
    }
}

