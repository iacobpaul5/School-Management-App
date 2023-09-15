//using SchoolManagement.API.Data;
//using SchoolManagement.API.DTOs;
//using SchoolManagement.API.Entities;

//namespace SchoolManagement.API.Services.FieldsOfStudyService
//{
//    public class FieldsOfStudyRepository : IFieldsOfStudyRepository
//    {
//        private readonly DataBaseContext _context;

//        public FieldsOfStudyRepository(DataBaseContext context)
//        {
//            _context = context;
//        }

//        public IEnumerable<FieldsOfStudies> GetAllFieldsOfStudy()
//        {
//            return _context.FieldsOfStudies.ToList();
//        }

//        public FieldsOfStudies GetFieldsOfStudyById(int fieldOfStudyId)
//        {
//            return _context.FieldsOfStudies.FirstOrDefault(fieldOfStudy => fieldOfStudy.FieldOfStudyID == fieldOfStudyId);
//        }



//        public void AddFieldsOfStudy(FieldsOfStudiesDto fieldsOfStudyDto)
//        {
//            var fieldOfStudy = new FieldsOfStudies
//            {
//                FieldOfStudyID = fieldsOfStudyDto.FieldOfStudyID,
//                FieldName = fieldsOfStudyDto.FieldName,
//                TeacherID = fieldsOfStudyDto.TeacherID,
//                YearID = fieldsOfStudyDto.YearID

//            };

//            _context.FieldsOfStudies.Add(fieldOfStudy);
//            _context.SaveChanges();
//        }



//        public void DeleteFieldsOfStudy(int fieldOfStudyID)
//        {
//            var existingFieldOfStudy = _context.FieldsOfStudies.Find(fieldOfStudyID);
//            if (existingFieldOfStudy != null)
//            {
//                _context.FieldsOfStudies.Remove(existingFieldOfStudy);
//                _context.SaveChanges();
//            }
//        }

//        public void UpdateFieldsOfStudy(int fieldOfStudiesId, FieldsOfStudiesDto fieldsOfStudyDto)
//        {
//            var existingFieldOfStudy = _context.FieldsOfStudies.Find(fieldOfStudiesId);

//            if (existingFieldOfStudy == null)
//            {
//                throw new ArgumentException("FieldOfStudy not found");
//            }

//            existingFieldOfStudy.FieldOfStudyID = fieldsOfStudyDto.FieldOfStudyID;
//            existingFieldOfStudy.FieldName = fieldsOfStudyDto.FieldName;
//            existingFieldOfStudy.TeacherID= fieldsOfStudyDto.TeacherID;
//            existingFieldOfStudy.YearID = fieldsOfStudyDto.YearID;
            

//            _context.SaveChanges();
//        }

        
//    }
//}
