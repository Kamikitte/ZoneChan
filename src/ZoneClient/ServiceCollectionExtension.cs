using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ZoneChan.ZoneClient.Games;

namespace ZoneChan.ZoneClient;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddZoneClient(this IServiceCollection services)
    {
        services.AddOptions<ZoneOptions>().BindConfiguration(ZoneOptions.SectionName);

        services.AddHttpClient<IGameClient, GameClient>((provider, client) =>
        {
            var options = provider.GetRequiredService<IOptions<ZoneOptions>>();
            client.BaseAddress = options.Value.ParsedBaseUri;
        });
        
        return services;
    }
}