import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Student } from 'src/models/student-model';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css']
})
export class StudentEditComponent {
  @Input() student: Student | null = null; 
  @Output() update = new EventEmitter<Student>();
  @Output() cancel = new EventEmitter<Student>();

  updateStudent(): void {
    if (this.student) {
      this.update.emit(this.student);
    }
  }
  cancelEdit(): void {
    this.cancel.emit();
  }

  
}
