using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data.models;

namespace Repository.interfaces
{
    public interface IEmployeeRepository
    {
        Task<IList<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(Guid id);
        Task<Employee> SaveEmployee(Employee emp);
        Task<Employee> DeleteEmployeeById(Guid id);
    }
}