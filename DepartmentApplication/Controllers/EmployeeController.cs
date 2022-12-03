using DepartmentApplication.Models;
using DepartmentApplication.Services.Interfaces;
using DepartmentApplication.Utilities.Pagination;
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
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            Paginator<Employee> pagination = await _employeeService.GetPaginatedData(page, take);
            return View(pagination);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.departments = await _employeeService.CreateDepartmentSelectList();
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
            ViewBag.departments = await _employeeService.CreateDepartmentSelectList();
            return View(departmentUpdateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EmployeeUpdateVM updateVM)
        {            
            if (!ModelState.IsValid) {
                ViewBag.departments = await _employeeService.CreateDepartmentSelectList();
                Employee employee = await _employeeService.GetById(updateVM.Id);
                updateVM.DepartmentName = employee.Department.Name;
                return View(updateVM);
            } 
            await _employeeService.Update(updateVM);

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Detail(int id)
        {
            EmployeeGetVM employeeGetVM = await _employeeService.Details(id);
            return View(employeeGetVM);
        }
    }
}
