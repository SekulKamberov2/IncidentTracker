namespace IncidentTracker.Api.DTOs
{
    public record IncidentResponse(string Id, string Title, string Status, DateTime CreatedAt);
}
