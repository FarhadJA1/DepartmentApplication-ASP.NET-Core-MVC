using DepartmentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Repositories.Interfaces
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        Task<Department> GetDepartmentWithStudents(int id);
    }
}
