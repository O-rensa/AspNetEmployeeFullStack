using Employee.Application.Employee.Dto;

namespace Employee.Application.Shared
{
    public interface IEmployeeService
    {
        Task<List<GetEmployeeDto>> GetAllEmployee();

        Task<GetEmployeeForViewOrUpdateDto?> GetEmployeeById(Guid id);

        Task CreateOrUpdateEmployee(CreateOrEditEmployeeDto employee);

        Task DeleteEmployee(Guid employeeId);
    }
}
