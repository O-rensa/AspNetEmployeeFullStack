using Employee.Core.Employee;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data.Context
{
    public class ProjectContext(DbContextOptions<ProjectContext> options) : DbContext(options)
    {
        public DbSet<EmployeeModel> Employees => Set<EmployeeModel>();
    }
}
