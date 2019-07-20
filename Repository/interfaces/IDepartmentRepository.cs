using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data.models;

namespace Repository.interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(Guid id);
        Task<Department> CreateDepartment(Department dep);
        Task<Department> UpdateDepartment(Department dep);
        Task<Department> DeleteDepartmentById(Guid id);
    }
}