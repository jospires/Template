export interface Project {
  id: number;
  teamId: number
  name: string;
  description: string;
  startDate: Date;
  expectedEndDate: Date;
  endDate: Date;
  team: any;
}
