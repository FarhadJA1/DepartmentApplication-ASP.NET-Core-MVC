using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }        
        public bool SoftDeleted { get; set; }
    }
}
