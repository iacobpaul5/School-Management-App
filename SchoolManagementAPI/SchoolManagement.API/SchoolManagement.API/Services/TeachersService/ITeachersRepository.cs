using SchoolManagement.API.DTOs;
using SchoolManagement.API.Entities;

namespace SchoolManagement.API.Services.TeachersService
{
    public interface ITeachersRepository
    {
        IEnumerable<Teachers> GetAllTeachers();
        Teachers GetTeacherById(int teacherId);
        void AddTeacher(TeachersDto teacherDto);
        void UpdateTeacher(int teacherId, TeachersDto teacherDto);
        void DeleteTeacher(int teacherId);
    }
}
