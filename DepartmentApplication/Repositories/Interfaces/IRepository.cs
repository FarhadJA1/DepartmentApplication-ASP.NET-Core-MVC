using DepartmentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentApplication.Repositories.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task Create(T enity);
        Task Update();
        Task Delete(T entity);
    }
}
