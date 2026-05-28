namespace IncidentTracker.Api.Services
{
    using IncidentTracker.Api.DTOs;
    using IncidentTracker.Api.Models;
    using IncidentTracker.Api.Storage;

    public class IncidentService
    {
        private readonly IncidentStore _store; 
        public IncidentService(IncidentStore store) => _store = store;

        public async Task<List<IncidentResponse>> GetAll()
        {
            var items = await _store.GetAll();
            return items.Select(x => new IncidentResponse(x.Id, x.Title, x.Status.ToString(), x.CreatedAt)).ToList();
        }

        public async Task<IncidentResponse> Create(string title)
        {
            var incident = new Incident { Title = title };
            await _store.Add(incident);

            return new IncidentResponse(incident.Id, incident.Title, incident.Status.ToString(), incident.CreatedAt);
        }

        public async Task<bool> Resolve(string id)
        {
            var incident = await _store.Get(id);
            if (incident == null) return false;

            incident.Status = IncidentStatus.Resolved;
            await _store.Update(incident);

            return true;
        }
    }
}
