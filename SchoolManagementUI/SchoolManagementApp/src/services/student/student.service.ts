import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from 'src/models/student-model';
import { HttpClient } from '@angular/common/http';
import { Students } from 'src/models/students-model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  
  private apiStudentsDetailsUrl = 'https://localhost:7160/api/students/GetStudentsWithDetails'; 
  private apiUrl = 'https://localhost:7160/api/students'; 
  constructor(private http: HttpClient) { }

  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(this.apiUrl);
  }

  addStudent(student: Student): Observable<Student> {
    return this.http.post<Student>(this.apiUrl, student);
  }

  updateStudent(student: Student): Observable<void> {
    const url = `${this.apiUrl}/${student.studentID}`;
    return this.http.put<void>(url, student);
  }

  deleteStudent(studentID: number): Observable<void> {
    const url = `${this.apiUrl}/${studentID}`;
    return this.http.delete<void>(url);
  }

  getAllStudentsWithDetails(): Observable<Students[]> {
    return this.http.get<Students[]>(this.apiStudentsDetailsUrl);
  }

  
}
