using DepartmentApplication.Models;
using DepartmentApplication.Services.Interfaces;
using DepartmentApplication.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _employeeService.GetAll();
            
            return View(employees);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.departments = await CreateDepartmentSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateVM employeeCreateVM)
        {
            if (!ModelState.IsValid) return View();
            await _employeeService.Create(employeeCreateVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            Employee employee = await _employeeService.GetById(id);
            if (employee == null) return NotFound();
            EmployeeUpdateVM departmentUpdateVM = new EmployeeUpdateVM()
            {
                Id = employee.Id,
                Fullname = employee.Fullname,
                DepartmentName = employee.Department.Name
            };
            ViewBag.departments = await CreateDepartmentSelectList();
            return View(departmentUpdateVM);
        }
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EmployeeUpdateVM updateVM)
        {
            if (!ModelState.IsValid) return View(updateVM);
            await _departmentService.Update(updateVM);

            return RedirectToAction(nameof(Index));

        }*/


        private async Task<SelectList> CreateDepartmentSelectList()
        {
            List<Department> departments = await _departmentService.GetAll();
            return new SelectList(departments, "Id", "Name");
        }

    }
}
