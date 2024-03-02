using EmployeeDemoGraphQL.Models;
using EmployeeDemoGraphQL.Queries;
using EmployeeDemoGraphQL.Schemas;
using EmployeeDemoGraphQL.Services;
using GraphQL;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<EmployeeDetailsType>();
builder.Services.AddSingleton<EmployeeQuery>();
builder.Services.AddSingleton<ISchema, EmployeeDetailsSchema>();
builder.Services.AddGraphQL(b => b
    .AddAutoSchema<EmployeeQuery>()  // schema
    .AddSystemTextJson());   // serializer

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQL<ISchema>("/graphql");            // url to host GraphQL endpoint
    app.UseGraphQLPlayground(
        "/",                               // url to host Playground at
        new GraphQL.Server.Ui.Playground.PlaygroundOptions
        {
            GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
            SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
        });
}


app.UseHttpsRedirection();

app.Run();
