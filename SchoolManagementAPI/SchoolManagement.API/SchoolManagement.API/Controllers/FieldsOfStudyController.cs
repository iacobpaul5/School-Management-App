//using Microsoft.AspNetCore.Mvc;
//using SchoolManagement.API.DTOs;
//using SchoolManagement.API.Services.FieldsOfStudyService;

//namespace SchoolManagement.API.Controllers
//{
//    [Route("api/fields-of-study")]
//    [ApiController]
//    public class FieldsOfStudyController : ControllerBase
//    {
//        private readonly IFieldsOfStudyRepository _fieldsOfStudyRepository;

//        public FieldsOfStudyController(IFieldsOfStudyRepository fieldsOfStudyRepository)
//        {
//            _fieldsOfStudyRepository = fieldsOfStudyRepository;
//        }

//        [HttpGet]
//        public IActionResult GetAllFieldsOfStudy()
//        {
//            try
//            {
//                var fieldOfStudy = _fieldsOfStudyRepository.GetAllFieldsOfStudy();
//                return Ok(fieldOfStudy);
//            }
//            catch (Exception ex)
//            {
                
//                if (ex.InnerException != null)
//                {
//                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
//                }

//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpGet("{id}", Name = "GetFieldOfStudyById")]
//        public IActionResult GetFieldOfStudyById(int id)
//        {
//            try
//            {
//                var fieldOfStudy = _fieldsOfStudyRepository.GetFieldsOfStudyById(id);

//                if (fieldOfStudy == null)
//                {
//                    return NotFound();
//                }

//                return Ok(fieldOfStudy);
//            }
//            catch (Exception ex)
//            {
                
//                if (ex.InnerException != null)
//                {
//                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
//                }

//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpPost]
//        public IActionResult AddFieldOfStudy([FromBody] FieldsOfStudiesDto fieldOfStudyDto)
//        {
//            try
//            {
//                if (fieldOfStudyDto == null)
//                {
//                    return BadRequest("FieldOfStudy object is null");
//                }

//                _fieldsOfStudyRepository.AddFieldsOfStudy(fieldOfStudyDto);

//                return CreatedAtRoute("GetFieldOfStudyById", new { id = fieldOfStudyDto.FieldOfStudyID }, fieldOfStudyDto);
//            }
//            catch (Exception ex)
//            {
                
//                if (ex.InnerException != null)
//                {
//                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
//                }

//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateFieldOfStudy(int id, [FromBody] FieldsOfStudiesDto fieldsOfStudyDto)
//        {
//            try
//            {
//                if (fieldsOfStudyDto == null)
//                {
//                    return BadRequest("FieldOfStudy object is null");
//                }

//                _fieldsOfStudyRepository.UpdateFieldsOfStudy(id, fieldsOfStudyDto);

//                return NoContent();
//            }
//            catch (Exception ex)
//            {
                
//                if (ex.InnerException != null)
//                {
//                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
//                }

//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeleteFieldOfStudy(int id)
//        {
//            try
//            {
//                _fieldsOfStudyRepository.DeleteFieldsOfStudy(id);

//                return NoContent();
//            }
//            catch (Exception ex)
//            {
                
//                if (ex.InnerException != null)
//                {
//                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
//                }

//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }
//    }
//}







