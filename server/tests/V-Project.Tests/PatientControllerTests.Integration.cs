using V_Project.Server;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using V_Project.Application;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using V_Project.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Text;
using System;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Serilog;

namespace V_Project.Tests;

public class PatientControllerTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private HttpClient _client;

    public PatientControllerTests(WebApplicationFactory<Startup> factory)
    {
        _client = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services
                            .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                        services.Remove(dbContextOptions);

                        services
                         .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("ProjectLocalDb"));

                    });
                })
            .CreateClient();
    }
    [Fact]
    public async Task GetAsync_PictureDoesNotExist_NotFound()
    {
        var response = await _client.GetAsync("/api/patients?");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Post_CreateNewPatient_ViewNewPatient()
    {
        var model = new PostPatientDto()
        {
            Name = "Gregorz",
            DateOfBirth = new DateOnly(1995, 3, 15),
            Pesel = "12345678910",
            City = "Olsztyn",
            Contact = "Zosia",
            MobilePhone = "111-222-333"
        };

        var httpContent = model.ToJsonHttpContent();

        var response = await _client.PostAsync("/api/patients/", httpContent);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        
        response.Headers.Location.Should().NotBeNull();
    }
}
