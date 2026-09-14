using System.Net;
using AzureAIProxy.Tests.Fixtures;

namespace AzureAIProxy.Tests.Routes;

public class HealthRouteTests : IClassFixture<ProxyAppFixture>
{
    private readonly ProxyAppFixture _fixture;

    public HealthRouteTests(ProxyAppFixture fixture)
    {
        _fixture = fixture;
    }

    [SkippableFact]
    public async Task Healthz_ReturnsHealthyStatusAndRequestId()
    {
        Skip.IfNot(_fixture.Available, "Azurite not available");

        var request = new HttpRequestMessage(HttpMethod.Get, "/healthz");
        request.Headers.Add("X-Request-ID", "health-check-123");

        var response = await _fixture.Client.SendAsync(request);
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("health-check-123", response.Headers.GetValues("X-Request-ID").Single());
        Assert.Contains("healthy", body);
    }
}
