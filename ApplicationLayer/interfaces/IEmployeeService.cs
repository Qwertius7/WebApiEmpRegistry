using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLayer.dto;

namespace ApplicationLayer.interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        Task<EmployeeDto> GetEmployeeById(Guid id);
        Task<EmployeeDto> CreateEmployee(EmployeeDto emp);
        Task<EmployeeDto> UpdateEmployee(EmployeeDto emp);
        Task<EmployeeDto> DeleteEmployeeById(Guid id);
    }
}