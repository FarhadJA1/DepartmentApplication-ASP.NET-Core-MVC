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
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task Create(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Department department)
        {
            department.SoftDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Department> Get(int id)
        {
            Department department = await _context.Departments.FirstOrDefaultAsync(m => m.Id == id);

            return department;
        }

        public async Task<List<Department>> GetAll()
        {
            List<Department> departments = await _context.Departments
                .Where(m => m.SoftDeleted == false)
                .OrderByDescending(m => m.Id)
                .ToListAsync();

            return departments;
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }
    }
}
