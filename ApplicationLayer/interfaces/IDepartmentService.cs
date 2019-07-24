using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLayer.dto;

namespace ApplicationLayer.interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentById(Guid id);
        Task<DepartmentDto> CreateDepartment(DepartmentDto dep);
        Task<DepartmentDto> UpdateDepartment(DepartmentDto dep);
        Task<DepartmentDto> DeleteDepartmentById(Guid id);
    }
}