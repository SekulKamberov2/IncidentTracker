namespace IncidentTracker.Api.Storage
{
    using System.Collections.Concurrent;
    using IncidentTracker.Api.Models;
 
    public class IncidentStore
    {
        private readonly ConcurrentDictionary<string, Incident> _data = new();

        public Task<List<Incident>> GetAll()
        {
            return Task.FromResult(_data.Values.ToList());
        }

        public Task<Incident?> Get(string id)
        {
            _data.TryGetValue(id, out var incident);
            return Task.FromResult(incident);
        }

        public Task Add(Incident incident)
        {
            _data[incident.Id] = incident;
            return Task.CompletedTask;
        }

        public Task Update(Incident incident)
        {
            _data[incident.Id] = incident;
            return Task.CompletedTask;
        }
    }
}
