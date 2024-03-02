using GraphQL.Types;

namespace EmployeeDemoGraphQL.Models;

public sealed class EmployeeDetailsType : ObjectGraphType<EmployeeDetails>
{
    public EmployeeDetailsType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.Age);
        Field(x => x.DeptName);
    }
}