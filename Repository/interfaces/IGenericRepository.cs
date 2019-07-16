using System;
using System.Collections.Generic;
using Repository.dto;

namespace Repository.interfaces
{
    public interface IGenericRepository
    {
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDto GetDepartmentById(Guid id);
        DepartmentDto CreateDepartment(DepartmentDto dep);
        DepartmentDto UpdateDepartment(DepartmentDto dep);
        DepartmentDto DeleteDepartmentById(Guid id);
        
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeById(Guid id);
        EmployeeDto CreateEmployee(EmployeeDto emp);
        EmployeeDto UpdateEmployee(EmployeeDto emp);
        EmployeeDto DeleteEmployeeById(Guid id);
    }
}