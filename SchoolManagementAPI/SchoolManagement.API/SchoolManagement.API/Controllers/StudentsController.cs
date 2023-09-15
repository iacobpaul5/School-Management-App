using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.DTOs;
using SchoolManagement.API.Entities;
using SchoolManagement.API.Services.StudentService;

namespace SchoolManagement.API.Controllers
{
    [Authorize]
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentRepository;

        public StudentsController(IStudentsRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _studentRepository.GetAllStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = _studentRepository.GetStudentById(id);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentDto studentDto)
        {
            try
            {
                if (studentDto == null)
                {
                    return BadRequest("Student object is null");
                }

                _studentRepository.AddStudent(studentDto);

                return CreatedAtRoute("GetStudentById", new { id = studentDto.StudentID }, studentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            try
            {
                if (studentDto == null)
                {
                    return BadRequest("Student object is null");
                }

                _studentRepository.UpdateStudent(id, studentDto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _studentRepository.DeleteStudent(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetStudentsWithDetails")]
        public IActionResult GetStudentsWithDetails()
        {
            try
            {
                var studentsWithDetails = _studentRepository.GetStudentsWithDetails();
                return Ok(studentsWithDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
