using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NJsonSchema.CodeGeneration.TypeScript;
using NSwag;
using NSwag.CodeGeneration.TypeScript;
using System.Text;

namespace V_Project.OpenApiGenerator;

public sealed class OpenApiGenerator : BackgroundService
{
    private readonly ILogger<OpenApiGenerator> logger;
    private readonly IServiceProvider serviceProvider;

    public OpenApiGenerator(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.logger = this.serviceProvider.GetRequiredService<ILogger<OpenApiGenerator>>();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var document =
            await OpenApiDocument.FromUrlAsync("https://localhost:6001/swagger/v1/swagger.json", stoppingToken);

        var settings = new TypeScriptClientGeneratorSettings
        {
            ClassName = "{controller}Client",
            GenerateClientClasses = false,
            GenerateDtoTypes = true,
            GenerateClientInterfaces = true,
            TypeScriptGeneratorSettings =
            {
                TypeStyle = TypeScriptTypeStyle.Interface
            }
        };

        var code = new TypeScriptClientGenerator(document, settings)
            .GenerateFile()
            .Replace("\n", "\r\n");

        const string path = @"../../../../client/src/types/BackendGenerated.ts";
        var directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            logger.LogInformation("OpenApiGenerator: Created dictionary.");
        }

        logger.LogInformation("OpenApiGenerator: Generating typescript code.");
        await File.WriteAllTextAsync(path, code, new UTF8Encoding(false), stoppingToken);
        logger.LogInformation("OpenApiGenerator: Generated typescript code.");
    }
}