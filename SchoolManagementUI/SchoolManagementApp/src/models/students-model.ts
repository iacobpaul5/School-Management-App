import { Grade } from "./garde-model";

export interface Students {
    studentID: number;
    firstName: string;
    lastName: string;
    email: string;
    grades: Grade[];
  }