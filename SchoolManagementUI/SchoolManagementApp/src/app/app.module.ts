import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { StudentComponent } from 'src/features/student/student.component';
import { StudentEditComponent } from 'src/features/student-edit/student-edit.component';
import { TeacherComponent } from 'src/features/teacher/teacher.component';
import { TeacherEditComponent } from 'src/features/teacher-edit/teacher-edit.component';
import { AuthenticationComponent } from 'src/features/authentication/authentication.component';
import { AuthInterceptor } from 'src/services/authentication/auth.interceptor';
import { StudentDetailsComponent } from 'src/features/student-details/student-details/student-details.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthenticationComponent,
    StudentComponent,
    StudentEditComponent,
    TeacherComponent,
    TeacherEditComponent,
    StudentDetailsComponent
    
    
  ],
  imports: [
    BrowserModule,
    FormsModule, 
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
  },],
  bootstrap: [AppComponent]
})
export class AppModule { }
