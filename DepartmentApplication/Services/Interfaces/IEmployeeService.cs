using DepartmentApplication.Models;
using DepartmentApplication.Utilities.Pagination;
using DepartmentApplication.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        Task Update(EmployeeUpdateVM employeeUpdateVM);
        Task Delete(int id);
        Task<Employee> GetById(int id);
        Task<EmployeeGetVM> Details(int id);
        Task<SelectList> CreateDepartmentSelectList();
        Task<Paginator<Employee>> GetPaginatedData(int currentPage, int take);

    }
}
