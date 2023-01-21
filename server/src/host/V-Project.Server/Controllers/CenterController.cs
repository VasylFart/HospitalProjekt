﻿using Microsoft.AspNetCore.Mvc;
using V_Project.Application;

namespace V_Project.Server.Controllers;

[ApiController]
[Route("api")]
public class CenterController : Controller
{
    private readonly ILogger<CenterController> logger;
    private readonly ICenterService service;

    public CenterController(ILogger<CenterController> logger, ICenterService service)
    {
        this.logger = logger;
        this.service = service;
    }

    [HttpGet("centers")]
    public IEnumerable<CenterDto> GetCenters()
    {
        logger.LogInformation("Getting Services");

        return service.GetCenters();
    }

    [HttpPost("centers")]
    public CenterDto Post([FromBody] PostCenterDto centerDto)
    {
        if (centerDto == null)
        {
            HttpContext.Response.StatusCode = 400;
            return null;
        }

        return service.AddNewCenter(centerDto);
    }

    [HttpPut("centers/{id}")]
    public CenterDto Put([FromBody] PostCenterDto centerDto, Guid id)
    {
        return service.UpdateCenter(centerDto, id);
    }

    [HttpDelete("centers/{id}")]
    public ActionResult Delete(Guid id)
    {
        service.DeleteCenter(id);
        return Ok();
    }
}
