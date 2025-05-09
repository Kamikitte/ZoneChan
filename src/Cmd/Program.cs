using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZoneChan.Cmd.Debugger;
using ZoneChan.ZoneClient;

namespace ZoneChan.Cmd;

internal static class Program
{
    private static async Task Main()
    {
        var builder = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices(services =>
            {
                services.AddZoneClient();
                services.AddTransient<DebuggerService>();
            })
            .Build();
        
        var debugger = builder.Services.GetRequiredService<DebuggerService>();  
        await debugger.Run();
    }
}