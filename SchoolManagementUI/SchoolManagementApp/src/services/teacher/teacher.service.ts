import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Teacher } from 'src/models/teacher-model';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  private apiUrl = 'https://localhost:7160/api/teachers'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  getTeacher(): Observable<Teacher[]> {
    return this.http.get<Teacher[]>(this.apiUrl);
  }


  updateTeacher(teacher: Teacher): Observable<void> {
    const url = `${this.apiUrl}/${teacher.teacherID}`;
    return this.http.put<void>(url, teacher);
  }

  deleteTeacher(teacherID: number): Observable<void> {
    const url = `${this.apiUrl}/${teacherID}`;
    return this.http.delete<void>(url);
  }

  
}
