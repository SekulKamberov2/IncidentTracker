export type IncidentStatus = "Open" | "Resolved";

export interface Incident {
  id: string;
  title: string;
  status: IncidentStatus;
  createdAt: string;
}
