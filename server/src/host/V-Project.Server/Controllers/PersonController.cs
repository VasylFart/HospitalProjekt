﻿using Microsoft.AspNetCore.Mvc;
using V_Project.Application;

namespace V_Project.Server;

[ApiController]
[Route("api")]
public class PersonController : Controller
{
    private readonly ILogger<PersonController> logger;
    private readonly IPersonService service;
    private IApplicationDbContext context;

    public PersonController(ILogger<PersonController> logger, IPersonService service, IApplicationDbContext context)
    {
        this.logger = logger;
        this.service = service;
        this.context = context;
    }

    [HttpGet("people")]
    public IEnumerable<PersonDto> GetPeople()
    {
        logger.LogInformation("Getting People");

        return service.GetPeople();
    }

    [HttpPost("people")]
    public PersonDto? Post([FromBody] PersonDto personDto)
    {
        if (personDto == null)
        {
            HttpContext.Response.StatusCode = 400;
            return null;
        }

        return new PersonDto();
    }


    [HttpDelete("people/{id}")]
    public void Delete(int id)
    { 
        context.Delete(id);
    }

    [HttpPut("people/{id}")]
    public void Put(int id, [FromBody] PersonDto personDto)
    {
    }
}
