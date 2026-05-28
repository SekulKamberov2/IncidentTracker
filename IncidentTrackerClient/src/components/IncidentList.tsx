import type { Incident } from "../types/incident";
import { resolveIncident } from "../api/incidentsApi";

export default function IncidentList({ incidents, onChanged }:{ incidents: Incident[]; onChanged: () => void }) {
  async function handleResolve(id: string) {
    try {
      await resolveIncident(id); 
      incidents.find(i => i.id === id)!.status = "Resolved";
      onChanged();
    } catch {
      alert("Failed to resolve incident");
    }
  }

  return (
    <div>
      {incidents.map((i) => (
        <div key={i.id} style={{ marginBottom: 10 }}>
          <b>{i.title}</b> — {i.status}
          {i.status === "Open" && (
            <button onClick={() => handleResolve(i.id)}>Resolve</button>
          )}
        </div>
      ))}
    </div>
  );
}