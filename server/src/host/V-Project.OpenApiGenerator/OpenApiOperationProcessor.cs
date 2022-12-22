using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace V_Project.OpenApiGenerator;

public sealed class OpenApiOperationProcessor : IOperationProcessor
{
    public bool Process(OperationProcessorContext context)
    {
        context.AddAntiforgeryHeader();
        return true;
    }
}