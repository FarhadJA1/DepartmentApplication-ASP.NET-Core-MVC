using DepartmentApplication.Data;
using DepartmentApplication.Models;
using DepartmentApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Repositories.Implementations
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Employee employee)
        {
            employee.SoftDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> Get(int id)
        {
            Employee employee = await _context.Employees.Include(m=>m.Department).FirstOrDefaultAsync(m => m.Id == id);
            
            return employee;
        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee> employees = await _context.Employees
                .Where(m => m.SoftDeleted == false)
                .Include(m=>m.Department)
                .OrderByDescending(m=>m.Id)
                .ToListAsync();

            return employees;
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }
    }
}
