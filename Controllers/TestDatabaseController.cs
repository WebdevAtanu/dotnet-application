using demoApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDatabaseController : ControllerBase // testdatabase controller inherited from controllerbase
    {
        private readonly MyDbContext context; // a readonly dbcontext instance

        public TestDatabaseController(MyDbContext context)
        {
            this.context = context; // asigning in constructor variable
        }

        // route for checking database connection
        [HttpGet("db-check")]
        public IActionResult CheckDatabaseConnection()
        {
            try
            {
                if (context.Database.CanConnect())
                {
                    return Ok("Database connection successful!");
                }
                else
                {
                    return StatusCode(500, "Database connection failed!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Database connection error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            try
            {
                var students = await context.Students.ToListAsync(); // list the data from database
                return Ok(students); // return the list
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Database connection error: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(long id)
        {
            try
            {
                var student = await context.Students.FindAsync(id); // find data by id
                if (student == null)
                {
                    return NotFound();
                }
                return student; // return the data
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Database connection error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            try
            {
                await context.Students.AddAsync(std); // added the data to the database
                await context.SaveChangesAsync(); // save the changes
                return Ok(std); // return entered data
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Database connection error: {ex.Message}");
            }
        }
    }
}
