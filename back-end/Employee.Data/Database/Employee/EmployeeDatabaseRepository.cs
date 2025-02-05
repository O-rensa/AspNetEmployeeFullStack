using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Data.Shared;

namespace Employee.Data.Database.Employee
{
    public class EmployeeDatabaseRepository : IEmployeeRepository
    {
        public string TestRepository()
        {
            return "Hello From Repository";
        }
    }
}
