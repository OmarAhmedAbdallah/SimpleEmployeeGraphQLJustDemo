using EmployeeDemoGraphQL.Queries;
using GraphQL.Types;

namespace EmployeeDemoGraphQL.Schemas;

public class EmployeeDetailsSchema : Schema
{
    public EmployeeDetailsSchema(IServiceProvider serviceProvider) : base(serviceProvider) {
        Query = serviceProvider.GetRequiredService<EmployeeQuery>();
    }
}