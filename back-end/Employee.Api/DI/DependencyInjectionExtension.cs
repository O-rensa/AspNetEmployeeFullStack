using Employee.Application.Employee;
using Employee.Application.Shared;
using Employee.Data.Database;
using Employee.Data.Database.Employee;
using Employee.Data.Shared;
using Microsoft.EntityFrameworkCore;

namespace Employee.Api.DI
{
    public static class DependencyInjectionExtension
    {
        public static WebApplicationBuilder InjectDependencies(this WebApplicationBuilder builder)
        {
            // Application Dependencies
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            // Data Dependencies
            builder.Services.AddScoped<IEmployeeRepository, EmployeeDatabaseRepository>();

            // Create Database Context
            var connString = builder.Configuration.GetConnectionString("MSSQLContext");
            builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(connString, b => b.MigrationsAssembly("Employee.Api")));

            return builder;
        }
    }
}
