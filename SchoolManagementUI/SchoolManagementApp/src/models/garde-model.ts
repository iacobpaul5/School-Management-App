import { FieldOfStudies } from "./fieldsOfStudy-model";


export interface Grade {
    gradeID: number;
    studentID: number;
    fieldOfStudyID: number;
    gradeValue: number;
    fieldOfStudy: FieldOfStudies;
    
  }