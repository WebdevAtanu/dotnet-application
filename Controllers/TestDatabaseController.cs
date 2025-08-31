using demoApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDatabaseController : ControllerBase
    {
        private readonly MyDbContext context; // a readonly dbcontext instance

        public TestDatabaseController(MyDbContext context)
        {
            this.context = context;
        }

        [HttpGet("connection")]
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
    }
}
