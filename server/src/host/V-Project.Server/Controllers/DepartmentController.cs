using Microsoft.AspNetCore.Mvc;
using V_Project.Application;
using V_Project.Application.Interfaces;

namespace V_Project.Server.Controllers
{
    [ApiController]
    [Route("api")]
    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> logger;
        private readonly IDepartmentDepartment service;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentDepartment service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet("departments")]
        public IEnumerable<DepartmentDto> GetDepartment()
        {
            logger.LogInformation("Getting Departments");

            return service.GetDepartment();
        }

        [HttpPost("departments")]
        public DepartmentDto Post([FromBody] PostDepartmentDto departmentDto)
        {
            if (departmentDto == null)
            {
                HttpContext.Response.StatusCode = 400;
                return null;
            }

            logger.LogInformation("Adding Department");

            return service.AddNewDepartment(departmentDto);
        }

        [HttpPut("departments/{id}")]
        public DepartmentDto Put([FromBody] PostDepartmentDto departmentDto, Guid id)
        {
            logger.LogInformation("Updating Department");

            return service.UpdateDepartment(departmentDto, id);
        }

        [HttpDelete("departments/{id}")]
        public ActionResult Delete(Guid id)
        {
            logger.LogInformation("Deleting Department");

            service.DeleteDepartment(id);
            return Ok();
        }
    }

}
