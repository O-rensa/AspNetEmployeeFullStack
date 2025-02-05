using Employee.Core.Employee;
using Employee.Data.Shared;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data.Database.Employee
{
    public class EmployeeDatabaseRepository : IEmployeeRepository
    {
        private readonly ProjectContext _projectContext;

        public EmployeeDatabaseRepository(
                ProjectContext projectContext
            )
        {
            _projectContext = projectContext;
        }

        public IQueryable<EmployeeModel> GetAll()
        {
            return _projectContext.Employees.AsQueryable<EmployeeModel>();
        }

        public async Task<EmployeeModel?> GetById(Guid EmployeeId)
        {
            return await _projectContext.Employees.FindAsync(EmployeeId);
        }

        public async Task CreateEmployee(EmployeeModel employee)
        {
            _projectContext.Employees.Add(employee);
            await _projectContext.SaveChangesAsync();
        }

        public async Task<EmployeeModel?> UpdateEmployee(EmployeeModel employee)
        {
            var exElem = await _projectContext.Employees.FindAsync(employee.Id);

            if (null == exElem)
            {
                return null;
            }

            _projectContext.Entry(exElem).CurrentValues.SetValues(employee);
            await _projectContext.SaveChangesAsync();

            return employee;
        }

        public async Task DeleteEmployee(Guid employeeId)
        {
            await _projectContext.Employees.Where(e => e.Id == employeeId).ExecuteDeleteAsync();
        }

        public string TestRepository()
        {
            return "Hello From Repository";
        }
    }
}
