using System.Diagnostics;

namespace SchoolManagement.API.Entities
{
    public class Students
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

       
        public List<Grades> Grades { get; set; }
    }
}
