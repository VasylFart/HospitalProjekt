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

    [HttpGet("person")]
    public IEnumerable<PersonDto> GetPerson()
    {
        logger.LogInformation("Person");

        return service.GetPerson();
    }
}
