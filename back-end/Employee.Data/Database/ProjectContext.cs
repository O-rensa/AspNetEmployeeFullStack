using Employee.Core.Employee;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data.Database
{
    public class ProjectContext(DbContextOptions<ProjectContext> options) : DbContext(options)
    {
        public DbSet<EmployeeModel> Employees => Set<EmployeeModel>();
    }
}
