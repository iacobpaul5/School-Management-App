using SchoolManagement.API.Data;
using SchoolManagement.API.DTOs;
using SchoolManagement.API.Entities;

namespace SchoolManagement.API.Services.TeachersService
{
    public class TeachersRepository:ITeachersRepository
    {
        private readonly DataBaseContext _context;

        public TeachersRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Teachers> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        public Teachers GetTeacherById(int teacherId)
        {
            return _context.Teachers.FirstOrDefault(teacher => teacher.TeacherID == teacherId);
        }

        public void AddTeacher(TeachersDto teachersDto)
        {
            var teacher = new Teachers
            {
                FirstName = teachersDto.FirstName,
                LastName = teachersDto.LastName,
                Email = teachersDto.Email,

            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }



        public void DeleteTeacher(int teacherId)
        {
            var existingTeacher = _context.Teachers.Find(teacherId);
            if (existingTeacher != null)
            {
                _context.Teachers.Remove(existingTeacher);
                _context.SaveChanges();
            }
        }

        public void UpdateTeacher(int teacheriId, TeachersDto teacherDto)
        {
            var existingTeacher = _context.Teachers.Find(teacheriId);

            if (existingTeacher == null)
            {
                throw new ArgumentException("Student not found");
            }

            existingTeacher.FirstName = teacherDto.FirstName;
            existingTeacher.LastName = teacherDto.LastName;
            existingTeacher.Email = teacherDto.Email;
           

            _context.SaveChanges();
        }

        
    }
}

