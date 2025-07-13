using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiJwtDemo.Models;

namespace WebApiJwtDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,POC")] // Allow both Admin and POC roles
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Jane Smith", Department = "HR", Salary = 45000 }
        };

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            employee.Id = employees.Count + 1;
            employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }
    }
}
