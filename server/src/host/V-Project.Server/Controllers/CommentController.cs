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

    [HttpPost("comments")]
    public CommentDto Post([FromBody] PostCommentDto commentDto)
    {
        if (commentDto == null)
        {
            HttpContext.Response.StatusCode = 400;
            return null;
        }

        logger.LogInformation("Adding Comment");

        return service.AddNewComment(commentDto);
    }

    [HttpPut("comments/{id}")]
    public CommentDto Put([FromBody] PostCommentDto commentDto, int id)
    {
        logger.LogInformation("Updating Comment");

        return service.UpdateComment(commentDto, id);
    }

    [HttpDelete("comments/{id}")]
    public ActionResult Delete(int id)
    {
        logger.LogInformation("Deleting Comment");

        service.DeleteComment(id);
        return Ok();
    }
}

