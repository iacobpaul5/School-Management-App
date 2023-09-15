import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationComponent } from 'src/features/authentication/authentication.component';
import { StudentComponent } from 'src/features/student/student.component';

const routes: Routes = [
  { path: '', component: AuthenticationComponent },
  { path: '', redirectTo: '/students', pathMatch: 'full' },
  { path: 'students', component: StudentComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
