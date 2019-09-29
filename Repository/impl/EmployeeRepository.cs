using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using data;
using data.models;
using Repository.interfaces;

namespace Repository.impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpRegistryContext _context;

        public EmployeeRepository(EmpRegistryContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        
        public async Task<IList<Employee>> GetAllEmployees()
        {
            return await _context.Employees.Include("Department").ToListAsync();
        }

        public Task<Employee> GetEmployeeById(Guid id)
        {
            return _context.Employees.Include("Department").FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> SaveEmployee(Employee emp)
        {
            if (emp == null) throw new ArgumentException(nameof(emp));
            _context.Employees.AddOrUpdate(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> DeleteEmployeeById(Guid id)
        {
            var employeeToDeletion = await _context.Employees.FirstAsync(e => e.Id == id);
            var resultAfterDeletion = _context.Employees.Remove(employeeToDeletion);
            await _context.SaveChangesAsync();
            return resultAfterDeletion;
        }
    }
}