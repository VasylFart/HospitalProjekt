using Microsoft.AspNetCore.Mvc;
using V_Project.Application;
using V_Project.Application.Interfaces;

namespace V_Project.Server.Controllers
{
    [ApiController]
    [Route("api")]
    public class StatusController : Controller
    {
        private readonly ILogger<StatusController> logger;
        private readonly IStatusService service;

        public StatusController(ILogger<StatusController> logger, IStatusService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet("statuss")]
        public IEnumerable<StatusDto> GetStatus()
        {
            logger.LogInformation("Getting Statuss");

            return service.GetStatus();
        }

        [HttpPost("statuss")]
        public StatusDto Post([FromBody] PostStatusDto statusDto)
        {
            if (statusDto == null)
            {
                HttpContext.Response.StatusCode = 400;
                return null;
            }

            logger.LogInformation("Adding Status");

            return service.AddNewStatus(statusDto);
        }

        [HttpPut("statuss/{id}")]
        public StatusDto Put([FromBody] PostStatusDto statusDto, int id)
        {
            logger.LogInformation("Updating Status");

            return service.UpdateStatus(statusDto, id);
        }

        [HttpDelete("statuss/{id}")]
        public ActionResult Delete(int id)
        {
            logger.LogInformation("Deleting Status");

            service.DeleteStatus(id);
            return Ok();
        }
    }

}
