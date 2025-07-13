using EmployeeWebAPI.Models;

namespace EmployeeWebAPI.Data
{
    public static class EmployeeData
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Email = "john@company.com", Department = "IT", Salary = 50000, JoinDate = DateTime.Now.AddYears(-2) },
            new Employee { Id = 2, Name = "Jane Smith", Email = "jane@company.com", Department = "HR", Salary = 45000, JoinDate = DateTime.Now.AddYears(-1) },
            new Employee { Id = 3, Name = "Mike Johnson", Email = "mike@company.com", Department = "Finance", Salary = 55000, JoinDate = DateTime.Now.AddMonths(-6) }
        };
    }
}
