import { Component } from '@angular/core';
import { Student } from 'src/models/student-model';
import { StudentService } from 'src/services/student/student.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {
  students: Student[] = [];
  selectedStudent: Student | null = null;

  showAddForm = false; 
  showEditForm = false;
  newStudent: Student = { studentID: 0, firstName: '', lastName: '', email: '' };

  constructor(private studentService: StudentService) { }

  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents(): void {
    this.studentService.getStudents().subscribe(students => {
      this.students = students;
    });
  }

  onSelect(student: Student): void {
    this.selectedStudent = student;
    
  }

  cancelEdit(): void {
    window.location.reload();
  }
  onAdd(student: Student): void {
    this.studentService.addStudent(student).subscribe(() => {
      this.loadStudents();
    });
  }

  onUpdate(student: Student): void {
    if (student) {
      this.studentService.updateStudent(student).subscribe(() => {
        this.loadStudents();
        this.selectedStudent = null;
      });
    }
  }

  onDelete(studentID: number): void {
    if (studentID) {
      this.studentService.deleteStudent(studentID).subscribe(() => {
        this.loadStudents();
        this.selectedStudent = null;
      });
    }
  }
  showAddStudentForm(): void {
 
    this.showAddForm = true;
  }

  addStudent(): void {
    this.showAddForm = false;
    this.studentService.addStudent(this.newStudent).subscribe(() => {
      this.loadStudents();
      this.newStudent = { studentID: 0, firstName: '', lastName: '', email: '' }; 
    });
  }

  cancelAddStudent(): void {
        this.showAddForm = false;
    this.newStudent = { studentID: 0, firstName: '', lastName: '', email: '' };
  }
}
