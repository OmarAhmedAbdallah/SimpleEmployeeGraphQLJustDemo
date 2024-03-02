namespace EmployeeDemoGraphQL.Models;

public class EmployeeModel
{
    public record Employee(int Id, string Name, int Age, int DeptId );

    public record Department(int Id, string Name);
}