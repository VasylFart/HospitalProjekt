using Microsoft.AspNetCore.Mvc;
using V_Project.Application;

namespace V_Project.Server;

[ApiController]
[Route("api")]
public class PeopleController : Controller
{
    private readonly ILogger<PeopleController> logger;
    private readonly IPeopleService service;

    public PeopleController(ILogger<PeopleController> logger, IPeopleService service)
    {
        this.logger = logger;
        this.service = service;
    }

    [HttpGet("people")]
    public IEnumerable<PeopleController> GetPeople()
    {
        logger.LogInformation("People");

        return (IEnumerable<PeopleController>)service.GetPeople();
    }
}
