using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Anthropic.HttpClients.Abstract;

/// <summary>
/// A cached HTTP transport for Anthropic. Authentication is attached by the OpenAPI client utility.
/// </summary>
public interface IAnthropicOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>Gets the shared HTTP transport using Anthropic:ClientBaseUrl. Configure the base URL before first use.</summary>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}

