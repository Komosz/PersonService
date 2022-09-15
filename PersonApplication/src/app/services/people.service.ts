import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { BehaviorSubject, Observable } from 'rxjs'
import { environment } from 'src/environments/environment';
import { Person } from './models/person';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  public behavior:BehaviorSubject<Person[]> = new BehaviorSubject(null);

  constructor(private http:HttpClient) { }

  public GetPeople(): void{
    this.http.get<Person[]>(`${environment.backendUrl}api/Persons`).subscribe(x=>this.behavior.next(x));
  }
  
  public AddPeople(person:Person): Observable<void> {
    return this.http.post<void>(`${environment.backendUrl}api/Persons`, person);
  }
  
  public DeletePerson(id:number): Observable<void> {
    return this.http.delete<void>(`${environment.backendUrl}api/Persons/${id}`);
  }
  
  public UpdatePerson(person:Person): Observable<void> {
    return this.http.put<void>(`${environment.backendUrl}api/Persons/${person.id}`,person);
  }
}