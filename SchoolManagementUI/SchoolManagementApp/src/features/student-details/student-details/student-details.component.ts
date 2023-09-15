import { Component } from '@angular/core';
import { Students } from 'src/models/students-model';
import { Grade } from 'src/models/garde-model';
import { StudentService } from 'src/services/student/student.service';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent {

  students: Students[] = [];
  studentsTableData: any[] = [];

  constructor(private studentService: StudentService) {}

  ngOnInit(): void {
    this.studentService.getAllStudentsWithDetails().subscribe(data => {
      console.log('Received data:', data);
  this.studentsTableData = [];

 data.forEach((student: Students) => { 
    student.grades.forEach((grade: Grade) => {
      const rowData = {
        studentID: student.studentID,
        firstName: student.firstName,
        lastName: student.lastName,
        email: student.email,
        fieldOfStudy: grade.fieldOfStudy.fieldName,
        teacher: `${grade.fieldOfStudy.teacher.firstName} ${grade.fieldOfStudy.teacher.lastName} ${grade.fieldOfStudy.teacher.email}`,
        gradeValue: grade.gradeValue,
        teacherFirstName: grade.fieldOfStudy.teacher.firstName,
            teacherLastName: grade.fieldOfStudy.teacher.lastName,
            teacherEmail: grade.fieldOfStudy.teacher.email,
      
      };
  
      this.studentsTableData.push(rowData);
    });
  });
});

}}
