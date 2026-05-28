using IncidentTracker.Api.Services;
using IncidentTracker.Api.Storage;

namespace IncidentTracker.Tests.Services;

public class IncidentServiceTests
{
    [Fact]
    public async Task Create_And_Resolve_Should_Work()
    { 
        var store = new IncidentStore();
        var service = new IncidentService(store);
         
        var created = await service.Create("Server down");
         
        Assert.Equal("Server down", created.Title);
        Assert.Equal("Open", created.Status);
         
        var resolved = await service.Resolve(created.Id);

        Assert.True(resolved);

        var all = await service.GetAll();

        Assert.Single(all);
        Assert.Equal("Resolved", all.First().Status);
    }
}
