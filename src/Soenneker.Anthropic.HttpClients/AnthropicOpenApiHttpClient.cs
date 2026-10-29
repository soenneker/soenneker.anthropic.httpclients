using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Anthropic.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Anthropic.HttpClients;

public sealed class AnthropicOpenApiHttpClient(IHttpClientCache httpClientCache, IConfiguration configuration) : IAnthropicOpenApiHttpClient
{
    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        string? configuredUrl = configuration["Anthropic:ClientBaseUrl"] ?? "https://api.anthropic.com";
        if (!Uri.TryCreate(configuredUrl, UriKind.Absolute, out Uri? baseAddress) ||
            baseAddress.Scheme != Uri.UriSchemeHttps || !string.IsNullOrEmpty(baseAddress.UserInfo) ||
            !string.IsNullOrEmpty(baseAddress.Query) || !string.IsNullOrEmpty(baseAddress.Fragment))
            throw new InvalidOperationException("Anthropic:ClientBaseUrl must be an absolute HTTPS API base URL without credentials, query, or fragment.");

        return httpClientCache.Get(nameof(AnthropicOpenApiHttpClient), baseAddress, static address => new HttpClientOptions
        {
            BaseAddress = new Uri(address.AbsoluteUri.TrimEnd('/') + "/"),
            DefaultRequestHeaders = new Dictionary<string, string> { ["Accept"] = "application/json" }
        }, cancellationToken);
    }

    public void Dispose() => httpClientCache.RemoveSync(nameof(AnthropicOpenApiHttpClient));

    public ValueTask DisposeAsync() => httpClientCache.Remove(nameof(AnthropicOpenApiHttpClient));
}

