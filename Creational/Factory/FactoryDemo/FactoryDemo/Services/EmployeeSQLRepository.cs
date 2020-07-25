using FactoryDemo.AppDbContext;
using FactoryDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryDemo.Services
{
    public class EmployeeSQLRepository : IEmployeeRepository
    {
        private ApplicationDbContext _context;

        public EmployeeSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.Include(c => c.EmployeeType).ToListAsync();
        }
    }
}
