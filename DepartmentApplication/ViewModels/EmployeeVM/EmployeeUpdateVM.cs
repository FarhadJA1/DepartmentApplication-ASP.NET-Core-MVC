using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.ViewModels.EmployeeVM
{
    public class EmployeeUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Fullname { get; set; }        
        [Required]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
