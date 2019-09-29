using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data.models;

namespace Repository.interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(Guid id);
        Task<Department> SaveDepartment(Department dep);
        Task DeleteDepartmentById(Department dep);
    }
}