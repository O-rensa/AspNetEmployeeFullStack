using Employee.Api.Data;
using Employee.Application.Employee;
using Employee.Application.Shared;
using Employee.Data.Database.Employee;
using Employee.Data.Shared;

namespace Employee.Api.DI
{
    public static class DependencyInjectionExtension
    {
        public static WebApplicationBuilder InjectDependencies(this WebApplicationBuilder builder)
        {
            // Application Dependencies
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            // Core Dependencies

            // Data Dependencies
            builder.Services.AddScoped<IEmployeeRepository, EmployeeDatabaseRepository>();

            // Database Dependencies
            var connString = builder.Configuration.GetConnectionString("MSSQLContext");
            builder.Services.AddSqlServer<ProjectContext>(connString);

            return builder;
        }
    }
}
