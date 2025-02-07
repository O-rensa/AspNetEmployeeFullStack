using Employee.Api.DI;
using Employee.Api.MigrationExtension;
using Employee.Api.V1Endpoints.Employee;



var builder = WebApplication.CreateBuilder(args);
// Allow Any Origin
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Dependency Injection
builder = builder.InjectDependencies();

// Build App
var app = builder.Build();
app.MapGet("/", () => "Server is ready..."); // Server root page

// V1 RouteGroup
var v1 = app.MapGroup("v1");

v1.MapEmployeeEndpoints();

// Initiate Migration on Start
await app.InitializeMigration();

app.UseCors();
app.Run();
