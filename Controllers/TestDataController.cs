using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demoApplication.Controllers
{
    [Route("api/[controller]")] // base route
    [ApiController] // indicate that it is an api controller
    public class TestDataController : ControllerBase // TestData controller inheritated from ControllerBase
    {
        [HttpGet("index")] // using the base route as an extension
        public IActionResult Index()
        {
            string hello = "hello index";
            return Ok(hello); // return a single text with status code 200
        }

        [HttpGet("jsondata")]
        public ActionResult JsonData()
        {
            var jsonData = new
            {
                name = "atanu",
                job = "coding"
            };
            return Ok(jsonData); // return a json data with status code 200
        }
        [HttpGet("getid/{id}")]
        public IActionResult getId(int id)
        {
            return Ok("the given id is " + id); // return the given id
        }
    }
}
