using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Application.Employee.Dto;
using Employee.Application.Shared;
using Employee.Core.Employee;
using Employee.Data.Shared;
using Microsoft.EntityFrameworkCore;

namespace Employee.Application.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<GetEmployeeDto>> GetAllEmployee()
        {
            var res =  await _employeeRepository.GetAll()
                .Select(e => new GetEmployeeDto
                {
                    EmployeeId = e.Id,
                    Name = e.FirstName + " " + e.MiddleName + " " + e.LastName,
                    Title = e.Title,
                })
                .ToListAsync();

            return res;
        }

        public async Task<GetEmployeeDto?> GetEmployeeById(Guid id)
        {
            var elem = await _employeeRepository.GetById(id);

            if (null == elem)
            {
                return null;
            }
            else
            {
                return new GetEmployeeDto
                {
                    EmployeeId= elem.Id,
                    Name = generateEmployeeName(elem.FirstName, elem.MiddleName, elem.LastName),
                    Title = elem.Title,
                };
            }
        }

        public async Task CreateOrUpdateEmployee(CreateOrEditEmployeeDto employee)
        {
            if (employee.Id.HasValue)
            {
                var elem = new EmployeeModel
                {
                    Id = employee.Id.Value,
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.LastName,
                    Age = employee.Age,
                    Title = employee.Title,
                };

                await _employeeRepository.UpdateEmployee(elem);
            }
            else
            {
                var elem = new EmployeeModel
                {
                    Id = Guid.NewGuid(),
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.LastName,
                    Age = employee.Age,
                    Title = employee.Title,
                };

                await _employeeRepository.CreateEmployee(elem);
            }

        }

        public async Task DeleteEmployee(Guid employeeId)
        {
            await _employeeRepository.DeleteEmployee(employeeId);
        }

        private string generateEmployeeName(string FName, string MName, string LName)
        {
            return FName + " " + MName + " " + LName;
        }
    }
}
