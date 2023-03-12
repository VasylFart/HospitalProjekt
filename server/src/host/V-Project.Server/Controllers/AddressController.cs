using Microsoft.AspNetCore.Mvc;
using V_Project.Application;

namespace V_Project.Server.Controllers;

[ApiController]
[Route("api")]
public class AddressController : Controller
{
    private readonly ILogger<AddressController> logger;
    private readonly IAddressService service;

    public AddressController(ILogger<AddressController> logger, IAddressService service)
    {
        this.logger = logger;
        this.service = service;
    }

    [HttpGet("addreses")]
    public IEnumerable<AddressDto> GetAddresses()
    {
        logger.LogInformation("Getting Addreses");

        return service.GetAddresses();
    }

    [HttpPost("addreses")]
    public AddressDto Post([FromBody] PostAddressDto addressDto)
    {
        if (addressDto == null)
        {
            HttpContext.Response.StatusCode = 400;
            return null;
        }

        logger.LogInformation("Adding Address");

        return service.AddNewAddress(addressDto);
    }

    [HttpPut("addreses/{id}")]
    public AddressDto Put([FromBody] PostAddressDto addressDto, Guid id)
    {
        logger.LogInformation("Updating Address");

        return service.UpdateAddress(addressDto, id);
    }

    [HttpDelete("addreses/{id}")]
    public ActionResult Delete(Guid id)
    {
        logger.LogInformation("Deleting Address");

        service.DeleteAddress(id);
        return Ok();
    }
}
