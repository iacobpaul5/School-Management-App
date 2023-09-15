using System.Diagnostics;

namespace SchoolManagement.API.Entities
{
    public class FieldsOfStudies
    {
        public int FieldOfStudyID { get; set; }

        public string FieldName { get; set; }
        public int TeacherID { get; set; }
        public int YearID { get; set; }

        public Teachers Teacher { get; set; }
        public YearOfStudies YearOfStudy { get; set; }

        public List<Grades> Grades { get; set; }
    }
}
