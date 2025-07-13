using demoApplication.Dto;
using demoApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await _studentService.GetAllStudents());
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<StudentResponse>> GetStudentById(Guid studentId)
        {
            var student = await _studentService.GetStudentById(studentId);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponse>> CreateStudent(StudentRequest studentRequest)
        {
            var created = await _studentService.CreateStudent(studentRequest);
            return CreatedAtAction(nameof(GetStudentById), new { studentId = created.StudentId }, created);
        }

        [HttpPut("{studentId}")]
        public async Task<ActionResult<StudentResponse>> UpdateStudent(Guid studentId, StudentRequest studentRequest)
        {
            var updated = await _studentService.UpdateStudent(studentId, studentRequest);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            var deleted = await _studentService.DeleteStudent(studentId);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
