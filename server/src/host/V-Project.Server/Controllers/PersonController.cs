using Microsoft.AspNetCore.Mvc;
using V_Project.Application;

namespace V_Project.Server;

[ApiController]
[Route("api")]
public class PersonController : Controller
{
    private readonly ILogger<PersonController> logger;
    private readonly IPersonService service;

    public PersonController(ILogger<PersonController> logger, IPersonService service)
    {
        this.logger = logger;
        this.service = service;
    }

    [HttpGet("people")]
    public IEnumerable<PersonDto> GetPeople()
    {
        logger.LogInformation("Getting People");

        return service.GetPeople();
    }

    [HttpDelete("people/{id}")]
    public void Delete(int id)
    {
    }
}
