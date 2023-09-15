import { Component } from '@angular/core';
import { Teacher } from 'src/models/teacher-model';
import { TeacherService } from 'src/services/teacher/teacher.service';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent {
  teachers: Teacher[] = [];
  selectedTeacher: Teacher | null = null;
  showEditForm = false;
  

  constructor(private teacherService: TeacherService) { }

  ngOnInit(): void {
   this.loadTeacher();
  }

  loadTeacher(): void {
    this.teacherService.getTeacher().subscribe(teachers => {
      this.teachers = teachers;
    });
  }

  onSelect(teacher: Teacher): void {
    this.selectedTeacher = teacher;
  }

  cancelEdit(): void {
    window.location.reload();
  }


  onUpdate(teacher: Teacher): void {
    if (teacher) {
      this.teacherService.updateTeacher(teacher).subscribe(() => {
        //this.loadTeacher();
        this.selectedTeacher = null;
      });
    }
  }

  onDelete(teacherID: number): void {
    if (teacherID) {
      this.teacherService.deleteTeacher(teacherID).subscribe(() => {
        //this.loadStudents();
        this.selectedTeacher = null;
      });
    }
  }

  
}
