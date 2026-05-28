import { useState } from "react";
import { createIncident } from "../api/incidentsApi";

export default function IncidentForm({ onCreated }: { onCreated: () => void }) {
  const [title, setTitle] = useState("");

  async function handleSubmit() {
    if (!title.trim()) return;

    try {
      await createIncident(title);
      setTitle("");
      onCreated();
    } catch {
      alert("Failed to create incident");
    }
  }

  return (
    <div style={{marginBottom: '1rem'}}>
      <input
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        placeholder="Incident title"
      />
      <button onClick={handleSubmit}>Create</button>
    </div>
  );
}
