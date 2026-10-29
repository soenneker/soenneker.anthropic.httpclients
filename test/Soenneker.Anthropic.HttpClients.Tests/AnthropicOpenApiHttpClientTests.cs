using Soenneker.Anthropic.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Anthropic.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class AnthropicOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IAnthropicOpenApiHttpClient _httpclient;

    public AnthropicOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IAnthropicOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
