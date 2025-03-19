using demoApplication.Dto;
using demoApplication.Interfaces;
using demoApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace demoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllProducts()
        {
            return Ok(await _studentService.GetStudents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetProductById(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent([FromBody] StudentDto studentDto)
        {
            var student = await _studentService.CreateStudent(studentDto);
            return CreatedAtAction(nameof(GetProductById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] StudentDto studentDto)
        {
            var updatedProduct = await _studentService.UpdateStudent(id, studentDto);
            if (updatedProduct == null)
                return NotFound();

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _studentService.DeleteStudent(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
