using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.DTOs;
using SchoolManagement.API.Services.TeachersService;

namespace SchoolManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersRepository _teachersRepository;

        public TeachersController(ITeachersRepository teacherRepository)
        {
            _teachersRepository = teacherRepository;
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            try
            {
                var teachers = _teachersRepository.GetAllTeachers();
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetTeacherById")]
        public IActionResult GetTeacherById(int id)
        {
            try
            {
                var teacher = _teachersRepository.GetTeacherById(id);

                if (teacher == null)
                {
                    return NotFound();
                }

                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddTeacher([FromBody] TeachersDto teacherDto)
        {
            try
            {
                if (teacherDto == null)
                {
                    return BadRequest("Teacher object is null");
                }

                _teachersRepository.AddTeacher(teacherDto);

                return CreatedAtRoute("GetTeacherById", new { id = teacherDto.TeacherID }, teacherDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] TeachersDto teacherDto)
        {
            try
            {
                if (teacherDto == null)
                {
                    return BadRequest("Teacher object is null");
                }

                _teachersRepository.UpdateTeacher(id, teacherDto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            try
            {
                _teachersRepository.DeleteTeacher(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
