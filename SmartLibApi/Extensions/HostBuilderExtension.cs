using Serilog;

namespace SmartLibApi.Extensions;

public static class HostBuilderExtension
{
    public static void ConfigureSerilog(this IHostBuilder host, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentName()
            .WriteTo.Debug()
            .WriteTo.Console()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        
        host.UseSerilog();
    }
}