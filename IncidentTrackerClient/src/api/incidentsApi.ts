import type { Incident } from "../types/incident";

const BASE_URL = "/api/incidents";

export async function getIncidents(): Promise<Incident[]> {
  const res = await fetch(BASE_URL);
  if (!res.ok) throw new Error(`HTTP ${res.status}`);
  return res.json();
}

export async function createIncident(title: string) {
  const res = await fetch(BASE_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ title }),
  });
  if (!res.ok) throw new Error(`HTTP ${res.status}`);
  return res.json();
}

export async function resolveIncident(id: string) {
  const res = await fetch(`${BASE_URL}/${id}/resolve`, {
    method: "POST",
  });
  
  if (!res.ok) throw new Error(`HTTP ${res.status}`); 
  return true;
}