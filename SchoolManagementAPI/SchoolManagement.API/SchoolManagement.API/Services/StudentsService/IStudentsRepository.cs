using SchoolManagement.API.DTOs;
using SchoolManagement.API.Entities;

namespace SchoolManagement.API.Services.StudentService
{
    public interface IStudentsRepository
    {
        IEnumerable<Students> GetAllStudents();
        Students GetStudentById(int studentId);
        void AddStudent(StudentDto studentDto);
        void UpdateStudent(int studentId, StudentDto studentDto);
        void DeleteStudent(int studentId);

        IEnumerable<StudentsDto> GetStudentsWithDetails();
    }
}
