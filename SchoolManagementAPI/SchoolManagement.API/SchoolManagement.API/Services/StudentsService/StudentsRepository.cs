using Microsoft.EntityFrameworkCore;
using SchoolManagement.API.Data;
using SchoolManagement.API.DTOs;
using SchoolManagement.API.Entities;
using SchoolManagement.API.Services.StudentService;
using System.Diagnostics;

namespace SchoolManagement.API.Services.StudentService
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly DataBaseContext _context;

        public StudentsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Students> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Students GetStudentById(int studentId)
        {
            return _context.Students.FirstOrDefault(student => student.StudentID == studentId);
        }

        public void AddStudent(StudentDto studentDto)
        {
            var student = new Students
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
               
            };

            _context.Students.Add(student);
            _context.SaveChanges();
        }



        public void DeleteStudent(int studentId)
        {
            var existingStudent = _context.Students.Find(studentId);
            if (existingStudent != null)
            {
                _context.Students.Remove(existingStudent);
                _context.SaveChanges();
            }
        }

        public void UpdateStudent(int studentId, StudentDto studentDto)
        {
            var existingStudent = _context.Students.Find(studentId);

            if (existingStudent == null)
            {
                throw new ArgumentException("Student not found");
            }

            existingStudent.FirstName = studentDto.FirstName;
            existingStudent.LastName = studentDto.LastName;
            existingStudent.Email = studentDto.Email;
           

            _context.SaveChanges();
        }

        public IEnumerable<StudentsDto> GetStudentsWithDetails()
        {
            var studentsWithDetails = _context.Students
    .Include(s => s.Grades)
        .ThenInclude(g => g.FieldOfStudy)
            .ThenInclude(f => f.Teacher)
    .Select(student => new StudentsDto
    {
        StudentID = student.StudentID,
        FirstName = student.FirstName,
        LastName = student.LastName,
        Email = student.Email,
        Grades = student.Grades.Select(grade => new GradesDto
        {
            GradeID = grade.GradeID,
            StudentID = grade.StudentID,
            FieldOfStudyID = grade.FieldOfStudyID,
            GradeValue = grade.GradeValue,
            FieldOfStudy = new FieldsOfStudiesDto
            {
                FieldOfStudyID = grade.FieldOfStudy.FieldOfStudyID,
                FieldName = grade.FieldOfStudy.FieldName,
                Teacher = new TeachersDto
                {
                    TeacherID = grade.FieldOfStudy.Teacher.TeacherID,
                    FirstName = grade.FieldOfStudy.Teacher.FirstName,
                    LastName = grade.FieldOfStudy.Teacher.LastName,
                    Email = grade.FieldOfStudy.Teacher.Email
                }
            }
        }).ToList(),
        Teacher = null 
    })
    .ToList();

            return studentsWithDetails;
        }

    }
}
