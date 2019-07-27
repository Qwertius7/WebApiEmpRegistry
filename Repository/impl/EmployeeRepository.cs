using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using data;
using data.models;
using Repository.interfaces;

namespace Repository.impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpRegistryContext _context;

        public EmployeeRepository()
        {
            _context = new EmpRegistryContext();
        }
        
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.Include("Department").ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await _context.Employees.Include("Department").SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> CreateEmployee(Employee emp)
        {
            var resultAfterCreation = _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return resultAfterCreation;
        }

        public async Task<Employee> UpdateEmployee(Employee emp)
        {
            var selectedEmployee = await _context.Employees.Include("Department").SingleAsync(e => e.Id == emp.Id);
            selectedEmployee.FirstName = emp.FirstName;
            selectedEmployee.LastName = emp.LastName;
            if (selectedEmployee.DepartmentId != emp.DepartmentId)
                selectedEmployee.SetDepartment(await _context.Departments.SingleAsync(d => d.Id == emp.DepartmentId));
            await _context.SaveChangesAsync();
            return selectedEmployee;
        }

        public async Task<Employee> DeleteEmployeeById(Guid id)
        {
            var employeeToDeletion = await _context.Employees.SingleAsync(e => e.Id == id);
            var resultAfterDeletion = _context.Employees.Remove(employeeToDeletion);
            await _context.SaveChangesAsync();
            return resultAfterDeletion;
        }
    }
}