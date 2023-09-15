using Newtonsoft.Json;

namespace SchoolManagement.API.DTOs
{
    public class FieldsOfStudiesDto
    {
        public int FieldOfStudyID { get; set; }
        public string FieldName { get; set; }
        public int TeacherID { get; set; }
        public int YearID { get; set; }

        public TeachersDto Teacher { get; set; }



    }
}
