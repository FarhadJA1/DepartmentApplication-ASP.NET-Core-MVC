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
    public class DepartmentRepository : IDepartmentRepository
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
        public async Task<Department> GetDepartmentWithStudents (int id)
        {
            Department department = await _context.Departments.Include(m=>m.Employees).FirstOrDefaultAsync(m => m.Id == id);

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
        public async Task<int> GetPageCount(int take)
        {
            int count = await _context.Departments.Where(m=>m.SoftDeleted==false).CountAsync();
            return (int)Math.Ceiling((decimal)count / take);
        }

        public async Task<List<Department>> GetDatasByCondition(int currentPage,int take)
        {
            List<Department> departments = await _context.Departments
                .Skip((currentPage - 1) * take)
                .Take(take)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
            return departments;
        }
    }
}
