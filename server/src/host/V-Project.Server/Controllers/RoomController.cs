using Microsoft.AspNetCore.Mvc;
using V_Project.Application;

namespace V_Project.Server.Controllers;

[ApiController]
[Route("api")]
public class RoomController : Controller
{
    private readonly ILogger<RoomController> logger;
    private readonly IRoomService service;

    public RoomController(ILogger<RoomController> logger, IRoomService service)
    {
        this.logger = logger;
        this.service = service;
    }

    [HttpGet("rooms")]
    public IEnumerable<RoomDto> GetRoom()
    {
        logger.LogInformation("Getting Rooms");

        return service.GetRoom();
    }

    [HttpPost("rooms")]
    public RoomDto Post([FromBody] PostRoomDto roomDto)
    {
        if (roomDto == null)
        {
            HttpContext.Response.StatusCode = 400;
            return null;
        }

        logger.LogInformation("Adding Room");

        return service.AddNewRoom(roomDto);
    }

    [HttpPut("rooms/{id}")]
    public RoomDto Put([FromBody] PostRoomDto roomDto, int id)
    {
        logger.LogInformation("Updating Room");

        return service.UpdateRoom(roomDto, id);
    }

    [HttpDelete("rooms/{id}")]
    public ActionResult Delete(int id)
    {
        logger.LogInformation("Deleting Room");

        service.DeleteRoom(id);
        return Ok();
    }
}
