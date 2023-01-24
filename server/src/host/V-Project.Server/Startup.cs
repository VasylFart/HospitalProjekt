using V_Project.OpenApiGenerator;
using V_Project.Application;
using V_Project.Infrastructure;

using Serilog;

namespace V_Project.Server;

public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        IsDevelopment = env.IsDevelopment();
        GenerateTsWithOpenApi = configuration.GenerateTsWithOpenApi();
        UseSpa = configuration.UseSpa();
    }

    public IConfiguration Configuration { get; }
    public bool IsDevelopment { get; }
    public bool GenerateTsWithOpenApi { get; }
    public bool UseSpa { get; }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddApplication();
        services.AddInfrastructure(Configuration);

        if (IsDevelopment)
            services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddHttpContextAccessor();
        services.AddHealthChecks();

        services.AddOptions();
        services.AddMemoryCache();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:3000"));
        });

        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddOpenApiGen(GenerateTsWithOpenApi);

        services.AddResponseCaching();

        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new Application.DateOnlyConverter());
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseSerilogRequestLogging(opts => { opts.IncludeQueryInRequestPath = true; });
        app.UseHttpsRedirection();
        app.UseOpenApiGen();

        app.UseExceptionHandlerMiddleware();

        app.UseCors();
        app.UseRouting();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        if (IsDevelopment && UseSpa)
            app.UseSpa(spa => { spa.UseProxyToSpaDevelopmentServer("http://localhost:3000"); });
    }
}