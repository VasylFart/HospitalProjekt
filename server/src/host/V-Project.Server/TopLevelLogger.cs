using Serilog;

namespace V_Project.Server;

public static class TopLevelLogger
{
    public static Serilog.Core.Logger CreateLogger()
    {
        var loggerConfiguration = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console();
        
        return loggerConfiguration.CreateLogger();
    }
}