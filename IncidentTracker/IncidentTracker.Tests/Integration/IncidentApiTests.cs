using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IncidentTracker.Tests.Integration;

public class IncidentApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    public IncidentApiTests(WebApplicationFactory<Program> factory) => _client = factory.CreateClient();

    [Fact]
    public async Task Full_Flow_Should_Work()
    {
        var createResponse = await _client.PostAsJsonAsync(
            "/api/incidents",
            new { title = "API failure" });

        createResponse.EnsureSuccessStatusCode();

        var incidents = await _client.GetFromJsonAsync<List<IncidentResponseTest>>(
            "/api/incidents");

        Assert.NotNull(incidents);
        Assert.Single(incidents);

        var id = incidents[0].Id;

        var resolveResponse = await _client.PostAsync(
            $"/api/incidents/{id}/resolve",
            null);

        Assert.True(resolveResponse.IsSuccessStatusCode);
    }
}
