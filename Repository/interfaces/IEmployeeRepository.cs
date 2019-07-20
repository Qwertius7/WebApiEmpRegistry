using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data.models;

namespace Repository.interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(Guid id);
        Task<Employee> CreateEmployee(Employee emp);
        Task<Employee> UpdateEmployee(Employee emp);
        Task<Employee> DeleteEmployeeById(Guid id);
    }
}