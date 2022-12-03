using DepartmentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.ViewModels.DepartmentVM
{
    public class DepartmentGetVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
