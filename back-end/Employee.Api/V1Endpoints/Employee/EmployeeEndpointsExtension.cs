using Employee.Application.Employee.Dto;
using Employee.Application.Shared;

namespace Employee.Api.V1Endpoints.Employee
{
    public static class EmployeeEndpointsExtension
    {
        public static RouteGroupBuilder MapEmployeeEndpoints(this RouteGroupBuilder builder)
        {
            var group = builder.MapGroup("employee");

            group.MapGet("getAll", async (IEmployeeService employeeService) => {
                return Results.Ok(await employeeService.GetAllEmployee());
            });

            group.MapGet("getEmployeeById/{id}", async (Guid id, IEmployeeService employeeService) =>
            {
                var res = await employeeService.GetEmployeeById(id);

                if (null == res)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(res);
                }
            });

            group.MapPost("createEmployee", async (CreateOrEditEmployeeDto payload, IEmployeeService employeeService) =>
            {
                await employeeService.CreateOrUpdateEmployee(payload);
                return Results.Created();
            });

            group.MapPut("editEmployee", async (CreateOrEditEmployeeDto payload, IEmployeeService employeeService) =>
            {
                await employeeService.CreateOrUpdateEmployee(payload);
                return Results.Ok();
            });

            group.MapDelete("deleteEmployee/{id}", async (Guid id, IEmployeeService employeeService) =>
            {
                await employeeService.DeleteEmployee(id);
                Results.Ok();
            });

            return builder;
        }
    }
}
