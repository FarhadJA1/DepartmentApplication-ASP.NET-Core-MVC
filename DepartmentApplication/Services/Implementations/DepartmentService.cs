using DepartmentApplication.Models;
using DepartmentApplication.Repositories.Implementations;
using DepartmentApplication.Repositories.Interfaces;
using DepartmentApplication.Services.Interfaces;
using DepartmentApplication.ViewModels.DepartmentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task Create(DepartmentCreateVM departmentCreateVM)
        {
            Department department = new Department()
            {
                Name=departmentCreateVM.Name,
                Address=departmentCreateVM.Address,
                SoftDeleted=false
            };
            await _departmentRepository.Create(department);
        }

        public async Task Delete(int id)
        {
            Department department = await _departmentRepository.Get(id);
            await _departmentRepository.Delete(department);
            
        }

        public async Task<Department> GetById(int id)
        {
            Department department = await _departmentRepository.Get(id);
            return department;
        }

        public async Task<List<Department>> GetAll()
        {
            List<Department> departments = await _departmentRepository.GetAll();
            return departments;
        }

        public async Task Update(DepartmentUpdateVM departmentUpdateVM)
        {
            Department department = await _departmentRepository.Get(departmentUpdateVM.Id);
            department.Name = departmentUpdateVM.Name;
            department.Address = departmentUpdateVM.Address;
            await _departmentRepository.Update();
        }

        public async Task<DepartmentGetVM> Details(int id)
        {
            Department department = await _departmentRepository.GetDepartmentWithStudents(id);
            DepartmentGetVM departmentGetVM = new DepartmentGetVM()
            {
                Name=department.Name,
                Address=department.Address,
                Employees=department.Employees
            };
            return departmentGetVM;
        }

     


    }
}
