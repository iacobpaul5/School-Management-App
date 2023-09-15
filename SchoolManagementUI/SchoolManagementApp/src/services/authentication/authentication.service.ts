import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from 'src/models/user-model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private apiUrl = 'http://localhost:5000/api/auth';

  constructor(private http: HttpClient) {}

  public register(user: User): Observable<any> {
    return this.http.post<any>(
      'https://localhost:7160/api/Auth/register',
      user
    );
  }

  public login(user: User): Observable<string> {
    return this.http.post('https://localhost:7160/api/Auth/login', user, {
      responseType: 'text',
    })
   
  }

  public getMe(): Observable<string> {
    return this.http.get('https://localhost:7160/api/Auth', {
      responseType: 'text',
    });
  }

  isAuthenticated(): boolean {
    
    const authToken = localStorage.getItem('authToken');
    return authToken !== null;
  }
  
}
