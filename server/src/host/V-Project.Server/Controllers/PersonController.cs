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

    [HttpPost("people")]
    public PersonDto? Post([FromBody] PostPersonDto personDto)
    {
        if (personDto == null)
        {
            HttpContext.Response.StatusCode = 400;
            return null;
        }
        return service.AddNewPerson(personDto);
    }

    [HttpPut("people/{id}")]
    public PersonDto Put([FromBody] PostPersonDto personDto, Guid id)
    {
        return service.UpdatePerson(personDto, id);
    }

    [HttpDelete("people/{id}")]
    public ActionResult Delete(Guid id)
    {
        service.DeletePerson(id);
        return Ok();
    }
}
