using EmployeeDemoGraphQL.Models;

namespace EmployeeDemoGraphQL.Services;

public class EmployeeService : IEmployeeService
{
    public EmployeeService()
    {

    }
    private List<EmployeeModel.Employee> employees = new List<EmployeeModel.Employee>
    {
        new EmployeeModel.Employee(1, "Tom", 25, 1),
        new EmployeeModel.Employee(2, "Henry", 28, 1),
        new EmployeeModel.Employee(3, "Steve", 30, 2),
        new EmployeeModel.Employee(4, "Ben", 26, 2),
        new EmployeeModel.Employee(5, "John", 35, 3),

    };

    private List<EmployeeModel.Department> departments = new List<EmployeeModel.Department>
    {
        new EmployeeModel.Department(1, "IT"),
        new EmployeeModel.Department(2, "Finance"),
        new EmployeeModel.Department(3, "HR"),
    };

    public List<EmployeeDetails> GetEmployees()
    {
        return employees.Select(emp => new EmployeeDetails { 
            Id = emp.Id,
            Name = emp.Name,
            Age = emp.Age,
            DeptName = departments.First(d => d.Id == emp.DeptId).Name,
        }).ToList();
            
    }
    public List<EmployeeDetails> GetEmployee(int empId)
    {
        return employees.Where(emp => emp.Id == empId).Select(emp => new EmployeeDetails
        {
            Id = emp.Id,
            Name = emp.Name,
            Age = emp.Age,
            DeptName = departments.First(d => d.Id == emp.DeptId).Name,
        }).ToList();
    }

    public List<EmployeeDetails>  GetEmployeesByDepartment(int deptId)
    {
        return employees.Where(emp => emp.DeptId == deptId).Select(emp => new EmployeeDetails
        {
            Id = emp.Id,
            Name = emp.Name,
            Age = emp.Age,
            DeptName = departments.First(d => d.Id == deptId).Name,
        }).ToList();
    }
}