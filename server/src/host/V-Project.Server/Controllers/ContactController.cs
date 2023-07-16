using Microsoft.AspNetCore.Mvc;
using V_Project.Application;

namespace V_Project.Server.Controllers;

[ApiController]
[Route("api")]
public class ContactController : Controller
{
    private readonly ILogger<ContactController> logger;
    private readonly IContactService service;

    public ContactController(ILogger<ContactController> logger, IContactService service)
    {
        this.logger = logger;
        this.service = service;
    }

    [HttpGet("contacts")]
    public IEnumerable<ContactDto> GetContacts()
    {
        logger.LogInformation("Getting Contact");

        return service.GetContact();
    }

    [HttpPost("contacts")]
    public ContactDto Post([FromBody] PostContactDto contactDto)
    {
        if (contactDto == null)
        {
            HttpContext.Response.StatusCode = 400;
            return null;
        }

        logger.LogInformation("Adding Contact");

        return service.AddNewContact(contactDto);
    }

    [HttpPut("contacts/{id}")]
    public ContactDto Put([FromBody] PostContactDto contactDto, Guid id)
    {
        logger.LogInformation("Updating Contact");

        return service.UpdateContact(contactDto, id);
    }

    [HttpDelete("contacts/{id}")]
    public ActionResult Delete(Guid id)
    {
        logger.LogInformation("Deleting Contact");

        service.DeleteContact(id);
        return Ok();
    }
}

