using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"value{id}";
        }

        // POST: api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            // Add logic to save the value
            return Ok(new { message = "Value created successfully", data = value });
        }

        // PUT: api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            // Add logic to update the value
            return Ok(new { message = $"Value {id} updated successfully", data = value });
        }

        // DELETE: api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Add logic to delete the value
            return Ok(new { message = $"Value {id} deleted successfully" });
        }
    }
}
