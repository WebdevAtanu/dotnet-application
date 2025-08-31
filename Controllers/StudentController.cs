using Azure;
using demoApplication.Dto;
using demoApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace demoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentResponse>>> GetAllStudents()
        {
            try
            {
                var response = await _studentService.GetAllStudents();
                if (response == null)
                    return NotFound();

                return Ok(new { status = true, response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the student: {ex.Message}");
            }
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<StudentResponse>> GetStudentById(int studentId)
        {
            try
            {
                var student = await _studentService.GetStudentById(studentId);

                if (student == null)
                    return NotFound();

                return Ok(new { status = true, student });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the student: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudent(StudentRequest studentRequest)
        {
            try
            {
                bool created = await _studentService.CreateStudent(studentRequest);

                if (created)
                    return Ok(new { status = true, message = "student information inserted successfully" });

                return BadRequest("Failed to insert student information");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the student: {ex.Message}");
            }
        }

        [HttpPut("{studentId}")]
        public async Task<ActionResult> UpdateStudent(int studentId, StudentRequest studentRequest)
        {
            try
            {
                bool updated = await _studentService.UpdateStudent(studentId, studentRequest);

                if (updated)
                    return Ok(new { status = true, message = "student information updated successfully" });

                return NotFound("Student not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating student: {ex.Message}");
            }
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            try
            {
                var deleted = await _studentService.DeleteStudent(studentId);

                if (!deleted)
                {
                    return NotFound(new { status = false, message = "Student not found" });
                }

                return Ok(new { status = true, message = "Student deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = false, message = $"An error occurred while deleting the student: {ex.Message}" });
            }
        }
    }
}
