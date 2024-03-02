using EmployeeDemoGraphQL.Models;
using EmployeeDemoGraphQL.Services;
using GraphQL;
using GraphQL.Types;

namespace EmployeeDemoGraphQL.Queries;

public sealed class EmployeeQuery : ObjectGraphType
{
    public EmployeeQuery(IEmployeeService employeeService) {
        Field<ListGraphType<EmployeeDetailsType>>(Name = "Employees").Resolve(x => employeeService.GetEmployees());
        Field<ListGraphType<EmployeeDetailsType>>(Name = "Employee")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}))
            .Resolve(x => employeeService.GetEmployee(x.GetArgument<int>("id")));
    }
}