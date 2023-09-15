using SchoolManagement.API.Controllers;
using SchoolManagement.API.Entities;

namespace SchoolManagement.API.DTOs
{
    public class GradesDto
    {
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public int FieldOfStudyID { get; set; }
        public decimal GradeValue { get; set; }

        public FieldsOfStudiesDto FieldOfStudy { get; set; }

        public Students Student { get; set; }
        
    }
}
