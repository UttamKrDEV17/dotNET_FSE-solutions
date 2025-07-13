using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiHandson.Models;
using WebApiHandson.Filters;

namespace WebApiHandson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        private readonly List<Employee> _employees;

        public EmployeeController()
        {
            _employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#", Level = "Advanced" },
                        new Skill { Id = 2, Name = "ASP.NET", Level = "Intermediate" }
                    },
                    DateOfBirth = new DateTime(1990, 1, 15)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Salary = 60000,
                    Permanent = false,
                    Department = new Department { Id = 2, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 3, Name = "Communication", Level = "Expert" }
                    },
                    DateOfBirth = new DateTime(1985, 5, 20)
                }
            };
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> Get()
        {
            // Throw exception for testing CustomExceptionFilter
            if (DateTime.Now.Millisecond % 2 == 0)
            {
                throw new Exception("Test exception for CustomExceptionFilter");
            }
            
            return Ok(_employees);
        }

        [HttpGet("standard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(GetStandardEmployeeList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required");
            }

            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            if (employee == null || id != employee.Id)
            {
                return BadRequest("Invalid employee data");
            }

            var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            var index = _employees.IndexOf(existingEmployee);
            _employees[index] = employee;
            
            return Ok(employee);
        }
    }
}
