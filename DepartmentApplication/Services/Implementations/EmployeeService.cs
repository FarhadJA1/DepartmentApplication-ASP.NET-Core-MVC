using DepartmentApplication.Models;
using DepartmentApplication.Repositories.Interfaces;
using DepartmentApplication.Services.Interfaces;
using DepartmentApplication.Utilities.Pagination;
using DepartmentApplication.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public EmployeeService(IRepository<Employee> employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            
        }

        public async Task Create(EmployeeCreateVM employeeCreateVM)
        {
            Employee employee = new Employee()
            {
                Fullname=employeeCreateVM.Name+" "+employeeCreateVM.Surname,
                DepartmentId=employeeCreateVM.DepartmentId,
                SoftDeleted=false

            };
            await _employeeRepository.Create(employee);
        }

        public async Task Delete(int id)
        {
            Employee employee = await _employeeRepository.Get(id);
            await _employeeRepository.Delete(employee);

        }

        public async Task<Employee> GetById(int id)
        {
            Employee employee = await _employeeRepository.Get(id);
            return employee;
        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee> employees = await _employeeRepository.GetAll();
            return employees;
        }

       

        public async Task Update(EmployeeUpdateVM employeeUpdateVM)
        {
            Employee employee = await _employeeRepository.Get(employeeUpdateVM.Id);
            employee.Fullname = employeeUpdateVM.Fullname;
            employee.DepartmentId = employeeUpdateVM.DepartmentId;
            await _employeeRepository.Update();
        }
        public async Task<EmployeeGetVM> Details(int id)
        {
            Employee employee = await _employeeRepository.Get(id);
            EmployeeGetVM employeeGetVM = new EmployeeGetVM()
            {
                Fullname=employee.Fullname,
                DepartmentName=employee.Department.Name
            };
            return employeeGetVM;
        }
        public async Task<SelectList> CreateDepartmentSelectList()
        {
            List<Department> departments = await _departmentRepository.GetAll();
            return new SelectList(departments, "Id", "Name");
        }
        public async Task<Paginator<Employee>> GetPaginatedData(int currentPage, int take)
        {
            int pageCount = await _employeeRepository.GetPageCount(take);
            List<Employee> employees = await _employeeRepository.GetDatasByCondition(currentPage, take);
            Paginator<Employee> pagination = new Paginator<Employee>(employees, currentPage, pageCount);
            return pagination;
        }
    }
}
