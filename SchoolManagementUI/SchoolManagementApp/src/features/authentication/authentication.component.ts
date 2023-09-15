import { Component, Input } from '@angular/core';
import { User } from 'src/models/user-model';

import { AuthenticationService } from 'src/services/authentication/authentication.service';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent {

  user = new User();
 

 isLoggedIn: boolean = false;
  constructor(private authService: AuthenticationService,) {

    this.isLoggedIn = this.authService.isAuthenticated();
  }
  isAuthenticated(): boolean {
    const authToken = localStorage.getItem('authToken');
    return !!authToken;}

  register(user: User) {
    this.authService.register(user).subscribe();
    window.location.reload();
  }

  login(user: User) {
    this.authService.login(user).subscribe((token: string) => {
      localStorage.setItem('authToken', token);
      this.isLoggedIn = true;
      window.location.reload();
 
    });
  }


  

  getme() {
    this.authService.getMe().subscribe((name: string) => {
      console.log(name);
    });
  }

  logout() {
    // Clear the token from storage
    localStorage.removeItem('authToken');
    this.isLoggedIn = false;
    window.location.reload();
     // Set the authentication status to false upon logout
  }
}
