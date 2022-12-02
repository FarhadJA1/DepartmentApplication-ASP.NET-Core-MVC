using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Models
{
    public class Employee:BaseEntity
    {
        public string Fullname { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
