using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private static List<Employee> employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "John Doe", Position = "Developer" },
        new Employee { Id = 2, Name = "Jane Smith", Position = "Manager" }
    };

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {
        return Ok(employees);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Employee> GetEmployee(int id)
    {
        var employee = employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
            return NotFound();
        
        return Ok(employee);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
    {
        if (employee == null)
            return BadRequest();

        employee.Id = employees.Max(e => e.Id) + 1;
        employees.Add(employee);
        
        return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee employee)
    {
        var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
        if (existingEmployee == null)
            return NotFound();

        existingEmployee.Name = employee.Name;
        existingEmployee.Position = employee.Position;
        
        return Ok(existingEmployee);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteEmployee(int id)
    {
        var employee = employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
            return NotFound();

        employees.Remove(employee);
        return NoContent();
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
}
