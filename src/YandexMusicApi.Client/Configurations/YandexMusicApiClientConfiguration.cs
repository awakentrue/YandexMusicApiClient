using Microsoft.Extensions.DependencyInjection;
using YandexMusicApi.Client.Http;

namespace YandexMusicApi.Client.Configurations;

public static class YandexMusicApiClientConfiguration
{
    public static IServiceCollection AddGuestYandexMusicApiClient(this IServiceCollection services,
        Action<HttpClient>? configureClient = null,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        var restClient = RestClient.Unauthorized(configureClient);
        
        services.Add(new ServiceDescriptor(typeof(IYandexMusicClient), _ => new YandexMusicClient(restClient), lifetime));
        
        return services;
    }
    
    public static IServiceCollection AddAuthorizedYandexMusicApiClient(this IServiceCollection services,
        string authenticationToken,
        string tokenType = "OAuth",
        Action<HttpClient>? configureClient = null,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        var restClient = RestClient.Authorized(authenticationToken, tokenType, configureClient);

        services.Add(new ServiceDescriptor(typeof(IYandexMusicClient), _ => new YandexMusicClient(restClient), lifetime));

        return services;
    }
}