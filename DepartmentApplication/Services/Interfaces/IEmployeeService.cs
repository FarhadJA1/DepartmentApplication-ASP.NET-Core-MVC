using DepartmentApplication.Models;
using DepartmentApplication.ViewModels.EmployeeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task Create(EmployeeCreateVM employeeCreateVM);
        Task Update();
        Task Delete(int id);
        Task<Employee> GetById(int id);

    }
}
