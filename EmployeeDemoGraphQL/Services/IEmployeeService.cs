using EmployeeDemoGraphQL.Models;

namespace EmployeeDemoGraphQL.Services;

public interface IEmployeeService
{
    public List<EmployeeDetails> GetEmployees();

    public List<EmployeeDetails> GetEmployee(int empId);

    public List<EmployeeDetails> GetEmployeesByDepartment(int deptId);
}