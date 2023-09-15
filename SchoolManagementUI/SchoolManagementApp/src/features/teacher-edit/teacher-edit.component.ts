import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Teacher } from 'src/models/teacher-model';

@Component({
  selector: 'app-teacher-edit',
  templateUrl: './teacher-edit.component.html',
  styleUrls: ['./teacher-edit.component.css']
})
export class TeacherEditComponent {
  @Input() teacher: Teacher | null = null; 
  @Output() update = new EventEmitter<Teacher>();
  @Output() cancel = new EventEmitter<Teacher>();
  updateTeacher(): void {
    if (this.teacher) {
      this.update.emit(this.teacher);
    }
  }

  cancelEdit(): void {
    this.cancel.emit(); 
  }
}
