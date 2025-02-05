using Employee.Application.Shared;

namespace Employee.Api.V1Endpoints.Employee
{
    public static class EmployeeEndpointsExtension
    {
        public static RouteGroupBuilder MapEmployeeEndpoints(this RouteGroupBuilder builder)
        {
            builder.MapGet("test", (IEmployeeService employeeService) => { 
               return employeeService.Test();
            });

            return builder;
        }
    }
}
