namespace SchoolManagement.API.Entities
{
    public class YearOfStudies
    {
        public int YearID { get; set; }
        public string YearName { get; set; }

        public List<FieldsOfStudies> FieldsOfStudy { get; set; }
    }
}
