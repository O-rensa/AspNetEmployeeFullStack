using Employee.Api.DI;
using Employee.Api.MigrationExtension;
using Employee.Api.V1Endpoints.Employee;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("MSSQLContext");

// Dependency Injection
builder = builder.InjectDependencies();

// Build App
var app = builder.Build();

// V1 RouteGroup
var v1 = app.MapGroup("v1");

v1.MapEmployeeEndpoints();

// Initiate Migration on Start
await app.InitializeMigration();

app.Run();
