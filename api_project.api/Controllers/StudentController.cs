using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_project.api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string[] students = new string[] { "Student 1", "Student 2", "Student 3" };
            return Ok(students);
        }
    }
}
