namespace SchoolManagement.API.Entities
{
    public class Grades
    {
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public int FieldOfStudyID { get; set; }
        public decimal GradeValue { get; set; }

        public Students Student { get; set; }
        public FieldsOfStudies FieldOfStudy { get; set; }
    }
}
