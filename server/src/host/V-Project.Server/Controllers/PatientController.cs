using Microsoft.AspNetCore.Mvc;
using V_Project.Application;

namespace V_Project.Server;

[ApiController]
[Route("api")]
public class PatientController : Controller
{
    private readonly ILogger<PatientController> logger;
    private readonly IPatientService service;

    public PatientController(ILogger<PatientController> logger, IPatientService service)
    {
        this.logger = logger;
        this.service = service;
    }

    [HttpGet("patients")]
    public IEnumerable<PatientDto> GetPatients()
    {
        logger.LogInformation("Getting Patient");

        return service.GetPatients();
    }

    [HttpPost("patients")]
    public PatientDto? Post([FromBody] PostPatientDto patientDto)
    {
        if (patientDto == null)
        {
            HttpContext.Response.StatusCode = 400;
            return null;
        }

        logger.LogInformation("Adding Patient");

        return service.AddNewPatient(patientDto);
    }

    [HttpPut("patients/{id}")]
    public PatientDto Put([FromBody] PostPatientDto patientDto, Guid id)
    {
        logger.LogInformation("Updating Patient");

        return service.UpdatePatient(patientDto, id);
    }

    [HttpDelete("patients/{id}")]
    public ActionResult Delete(Guid id)
    {
        logger.LogInformation("Deleting Patient");

        service.DeletePatient(id);
        return Ok();
    }
}
