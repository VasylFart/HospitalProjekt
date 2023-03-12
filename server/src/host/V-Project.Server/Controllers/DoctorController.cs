using Microsoft.AspNetCore.Mvc;
using V_Project.Application;

namespace V_Project.Server.Controllers;

[ApiController]
[Route("api")]
public class DoctorController : Controller
{
    private readonly ILogger<DoctorController> logger;
    private readonly IDoctorService service;

    public DoctorController(ILogger<DoctorController> logger, IDoctorService service)
    {
        this.logger = logger;
        this.service = service;
    }

    [HttpGet("doctors")]
    public IEnumerable<DoctorDto> GetDoctors()
    {
        logger.LogInformation("Getting Doctors");

        return service.GetDoctors();
    }

    [HttpPost("doctors")]
    public DoctorDto Post([FromBody] PostDoctorDto doctorDto)
    {
        if (doctorDto == null)
        {
            HttpContext.Response.StatusCode = 400;
            return null;
        }

        logger.LogInformation("Adding Center");

        return service.AddNewDoctor(doctorDto);
    }

    [HttpPut("doctors/{id}")]
    public DoctorDto Put([FromBody] PostDoctorDto doctorDto, Guid id)
    {
        logger.LogInformation("Updating Doctor");

        return service.UpdateDoctor(doctorDto, id);
    }

    [HttpDelete("doctors/{id}")]
    public ActionResult Delete(Guid id)
    {
        logger.LogInformation("Deleting Doctor");

        service.DeleteDoctor(id);
        return Ok();
    }
}
