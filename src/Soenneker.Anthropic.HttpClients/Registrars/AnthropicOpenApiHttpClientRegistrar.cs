using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Anthropic.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Anthropic.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class AnthropicOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="AnthropicOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddAnthropicOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IAnthropicOpenApiHttpClient, AnthropicOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="AnthropicOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddAnthropicOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IAnthropicOpenApiHttpClient, AnthropicOpenApiHttpClient>();

        return services;
    }
}
