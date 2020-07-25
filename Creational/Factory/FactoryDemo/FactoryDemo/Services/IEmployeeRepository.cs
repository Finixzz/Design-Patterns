using FactoryDemo.AppDbContext;
using FactoryDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryDemo.Services
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> CreateEmployeeAsync(Employee newEmployee);
    }
}
