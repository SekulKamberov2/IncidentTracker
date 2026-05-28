import { useEffect, useState } from "react";
import type { Incident } from "./types/incident";
import { getIncidents } from "./api/incidentsApi";
import IncidentForm from "./components/IncidentForm";
import IncidentList from "./components/IncidentList";

export default function App() {
  const [incidents, setIncidents] = useState<Incident[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState<boolean>(false);

  async function load() {
    try {
      setLoading(true);
      setError(null);
      const data = await getIncidents();
      setIncidents(data);
    } catch (err) {
      console.error("Load error:", err);
      setError("Failed to load incidents");
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => {
    load();
  }, []);

  return (
    <div style={{ padding: 20 }}>
      <nav style={{ marginBottom: 20 }}> 
      </nav>

      <h1>Incident Tracker</h1>

      {loading && <div>Loading...</div>}

      {error && (
        <div style={{ color: "red", marginBottom: 10 }}>
          {error}
          <div>
            <button onClick={load}>Retry</button>
          </div>
        </div>
      )}
 
      <IncidentForm onCreated={load} />
    
      <IncidentList incidents={incidents} onChanged={load} />
    </div>
  );
}