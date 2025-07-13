using Microsoft.AspNetCore.Mvc;
using EmployeeWebAPI.Models;
using EmployeeWebAPI.Data;

namespace EmployeeWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // GET: api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return Ok(EmployeeData.Employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var employee = EmployeeData.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required");
            }

            // Generate new ID
            employee.Id = EmployeeData.Employees.Max(e => e.Id) + 1;
            EmployeeData.Employees.Add(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            // Check if the id value is lesser than or equal to 0
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            // Find existing employee
            var existingEmployee = EmployeeData.Employees.FirstOrDefault(e => e.Id == id);
            
            // If not found in the hardcoded list
            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Update the employee data
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Email = updatedEmployee.Email;
            existingEmployee.Department = updatedEmployee.Department;
            existingEmployee.Salary = updatedEmployee.Salary;
            existingEmployee.JoinDate = updatedEmployee.JoinDate;

            // Filter and return the updated employee
            var updatedEmployeeResult = EmployeeData.Employees.FirstOrDefault(e => e.Id == id);
            return Ok(updatedEmployeeResult);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var employee = EmployeeData.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            EmployeeData.Employees.Remove(employee);
            return NoContent();
        }
    }
}
