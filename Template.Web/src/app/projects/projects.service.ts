import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { DatePipe } from '@angular/common';

import { Project } from './project.model';

@Injectable({
  providedIn: 'root'
})

export class ProjectsService {
  private apiUrl = 'https://localhost:7118/projects';

  constructor(private http: HttpClient) { }

  getProjects(skip: number, take: number): Observable<[Project[], number]> {
    const url = `${this.apiUrl}/list?skip=${skip}&take=${take}&sortBy=ID&sortOrder=desc`;
    return this.http.get<{ item1: Project[], item2: number }>(url).pipe(
      map(data => {
        return [data.item1, data.item2];
      }));
  }

  getProject(id: number): Observable<Project> {
    const url = `${this.apiUrl}/get?id=${id}`;
    return this.http.get<Project>(url);
  }

  createProject(project: Project): Observable<Project> {
    const url = `${this.apiUrl}/create`;
    return this.http.post<Project>(url, project);
  }

  updateProject(project: Project): Observable<Project> {
    const url = `${this.apiUrl}/update`;
    return this.http.put<Project>(url, project);
  }

  deleteProject(id: number): Observable<any> {
    const url = `${this.apiUrl}/delete?id=${id}`;
    return this.http.delete(url);
  }
}
