using DepartmentApplication.Models;
using DepartmentApplication.ViewModels.DepartmentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAll();
        Task Create(DepartmentCreateVM departmentCreateVM);
        Task Update(DepartmentUpdateVM departmentUpdateVM);
        Task Delete(int id);
        Task<Department> GetById(int id);
    }
}
