using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NJsonSchema;
using NSwag;
using NSwag.Generation.Processors.Contexts;

namespace V_Project.OpenApiGenerator;

public static class OpenApiExtensions
{
    public static IServiceCollection AddOpenApiGen(this IServiceCollection services, bool generateTsWithOpenApi)
    {
        services.AddSwaggerDocument(settings =>
        {
            settings.PostProcess = document =>
            {
                document.Info.Version = "v1";
                document.Info.Title = "V-Project WebAPI";
                document.Info.Description = "REST API for V-Project.";
            };
            settings.OperationProcessors.Add(new OpenApiOperationProcessor());
        });

        if (generateTsWithOpenApi)
            services
                .AddSingleton<IServiceProvider, ServiceProvider>()
                .AddSingleton<IHostedService, OpenApiGenerator>();

        return services;
    }

    public static IApplicationBuilder UseOpenApiGen(this IApplicationBuilder app)
    {
        return app.UseOpenApi()
            .UseSwaggerUi3(c => { c.AdditionalSettings.Add("displayRequestDuration", true); });
    }

    internal static void AddAntiforgeryHeader(this OperationProcessorContext context)
    {
        context.OperationDescription.Operation.Parameters.Add(
            new OpenApiParameter
            {
                Name = "RequestVerificationToken",
                Kind = OpenApiParameterKind.Header,
                Type = JsonObjectType.String,
                IsRequired = false,
                Description = "Anti-CSRF request verification token. Not needed for GET and HEAD requests.",
                Default = ""
            });
    }
}