namespace IncidentTracker.Api.Models
{
    public class Incident
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = string.Empty;
        public IncidentStatus Status { get; set; } = IncidentStatus.Open;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
