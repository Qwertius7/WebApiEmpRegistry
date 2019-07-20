using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using data;
using data.models;
using Repository.interfaces;

namespace Repository.impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpRegistryContext _context;

        protected EmployeeRepository()
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
            if (await _context.Employees.AnyAsync(e => e.Id == emp.Id)) 
                throw new Exception("User with such id already exists");
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> UpdateEmployee(Employee emp)
        {
            var selectedEmployee = await GetEmployeeById(emp.Id);
            if (selectedEmployee == null) throw new Exception("There is no such user");
            selectedEmployee.Department = emp.Department;
            selectedEmployee.FirstName = emp.FirstName;
            selectedEmployee.LastName = emp.LastName;
            await _context.SaveChangesAsync();
            return selectedEmployee;
        }

        public async Task<Employee> DeleteEmployeeById(Guid id)
        {
            if (!await _context.Employees.AnyAsync(e => e.Id == id)) 
                throw new Exception("There is no such user");
            var resultAfterDeletion = _context.Employees.Remove(
                _context.Employees.Single(e => e.Id == id));
            await _context.SaveChangesAsync();
            return resultAfterDeletion;
        }
    }
}