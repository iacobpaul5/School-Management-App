import { Teacher } from "./teacher-model";

export interface FieldOfStudies {
    fieldOfStudyID: number;
    fieldName: string;
    teacher: Teacher;
    
  }