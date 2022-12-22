namespace V_Project.Server;

public static class ConfigurationExtensions
{
    public static bool GenerateTsWithOpenApi(this IConfiguration configuration)
    {
        return configuration.GetValue<bool>("GenerateTsWithOpenApi");
    }

    public static bool UseSpa(this IConfiguration configuration)
    {
        return configuration.GetValue<bool>("UseSpa");
    }
}