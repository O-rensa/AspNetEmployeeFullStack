using Employee.Core.Employee;

namespace Employee.Data.Shared
{
    public interface IEmployeeRepository
    {
        IQueryable<EmployeeModel> GetAll();

        Task<EmployeeModel?> GetById(Guid EmployeeId);

        Task CreateEmployee(EmployeeModel employee);

        Task<EmployeeModel?> UpdateEmployee(EmployeeModel employee);

        Task DeleteEmployee(Guid employeeId);

        string TestRepository();
    }
}
