using DepartmentApplication.Models;
using DepartmentApplication.Repositories.Interfaces;
using DepartmentApplication.Services.Interfaces;
using DepartmentApplication.ViewModels.EmployeeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;     
        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
            
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

       

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
