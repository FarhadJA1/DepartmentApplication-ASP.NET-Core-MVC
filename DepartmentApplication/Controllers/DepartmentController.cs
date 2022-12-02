using DepartmentApplication.Models;
using DepartmentApplication.Services.Interfaces;
using DepartmentApplication.ViewModels.DepartmentVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            List<Department> departments = await _departmentService.GetAll();

            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentCreateVM departmentCreateVM)
        {
            if (!ModelState.IsValid) return View();
            await _departmentService.Create(departmentCreateVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Department department = await _departmentService.GetById(id);
            if (department == null) return NotFound();
            DepartmentUpdateVM departmentUpdateVM = new DepartmentUpdateVM()
            {
                Id=department.Id,
                Name=department.Name,
                Address=department.Address
            };
            return View(departmentUpdateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(DepartmentUpdateVM updateVM)
        {
            if (!ModelState.IsValid) return View(updateVM);
            await _departmentService.Update(updateVM);
            return RedirectToAction(nameof(Index));

        }

    }
}
