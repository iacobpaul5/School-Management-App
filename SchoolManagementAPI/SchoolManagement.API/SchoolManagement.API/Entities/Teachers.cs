namespace SchoolManagement.API.Entities
{
    public class Teachers
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<FieldsOfStudies> FieldsOfStudy { get; set; }
    }
}
