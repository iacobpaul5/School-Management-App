


using SchoolManagement.API.DTOs;

namespace SchoolManagement.API.Entities
{
    public class StudentsDto

    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<GradesDto> Grades { get; set; }
        public TeachersDto Teacher { get; set; }



    }
}


