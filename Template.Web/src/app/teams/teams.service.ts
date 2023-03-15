import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Team } from './team.model';

@Injectable({
  providedIn: 'root'
})

export class TeamsService {
  private apiUrl = 'https://localhost:7118/teams';

  constructor(private http: HttpClient) { }

  getTeams(skip: number, take : number): Observable<[Team[], number]> {
    const url = `${this.apiUrl}/list?skip=${skip}&take=${take}&sortBy=ID&sortOrder=desc`;
    return this.http.get<{ item1: Team[], item2: number }>(url).pipe(
      map(data => {
        return [data.item1, data.item2];
      }));
  }

  getAllTeams(): Observable<[Team[], number]> {
    const url = `${this.apiUrl}/list/all`;
    return this.http.get<{ item1: Team[], item2: number }>(url).pipe(
      map(data => {
        return [data.item1, data.item2];
      }));
  }

  getTeam(id: number): Observable<Team> {
    const url = `${this.apiUrl}/get?id=${id}`;
    return this.http.get<Team>(url);
  }

  createTeam(team: Team): Observable<Team> {
    const url = `${this.apiUrl}/create`;
    return this.http.post<Team>(url, team);
  }

  updateTeam(team: Team): Observable<Team> {
    const url = `${this.apiUrl}/update`;
    return this.http.put<Team>(url, team);
  }

  deleteTeam(id: number): Observable<any> {
    const url = `${this.apiUrl}/delete?id=${id}`;
    return this.http.delete(url);
  }
}
