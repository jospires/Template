import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Developer } from './developer.model';

@Injectable({
  providedIn: 'root'
})

export class DevelopersService {
  private apiUrl = 'https://localhost:7118/developers';

  constructor(private http: HttpClient) { }

  getDevelopers(skip: number, take: number): Observable<[Developer[], number]> {
    const url = `${this.apiUrl}/list?skip=${skip}&take=${take}&sortBy=ID&sortOrder=desc`;
    return this.http.get<{ item1: Developer[], item2: number }>(url).pipe(
      map(data => {
        return [data.item1, data.item2];
      }));
  }

  getDeveloper(id: number): Observable<Developer> {
    const url = `${this.apiUrl}/get?id=${id}`;
    return this.http.get<Developer>(url);
  }

  createDeveloper(developer: Developer): Observable<Developer> {
    const url = `${this.apiUrl}/create`;
    return this.http.post<Developer>(url, developer);
  }

  updateDeveloper(developer: Developer): Observable<Developer> {
    const url = `${this.apiUrl}/update`;
    return this.http.put<Developer>(url, developer);
  }

  deleteDeveloper(id: number): Observable<any> {
    const url = `${this.apiUrl}/delete?id=${id}`;
    return this.http.delete(url);
  }
}
