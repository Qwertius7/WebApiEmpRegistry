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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmpRegistryContext _context;
        
        public DepartmentRepository()
        {
            _context = new EmpRegistryContext();
        }
        
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(Guid id)
        {
            return await _context.Departments.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Department> CreateDepartment(Department dep)
        {
            if (await _context.Employees.AnyAsync(e => e.Id == dep.Id)) 
                throw new Exception("Department with such id already exists");
            _context.Departments.Add(dep);
            await _context.SaveChangesAsync();
            return dep;
        }

        public async Task<Department> UpdateDepartment(Department dep)
        {
            var selectedDepartment = await GetDepartmentById(dep.Id);
            if (selectedDepartment == null) return null;
            selectedDepartment.Title = dep.Title;
            selectedDepartment.Employees = dep.Employees;
            await _context.SaveChangesAsync();
            return dep;
        }

        public async Task<Department> DeleteDepartmentById(Guid id)
        {
            var departmentToDeletion = await _context.Departments.SingleOrDefaultAsync(d => d.Id == id);
            if (departmentToDeletion == null) return null;
            foreach (var emp in _context.Employees.Include("Department")
                .Where(emp => emp.Department.Id == departmentToDeletion.Id))
            {
                emp.Department = null;
            }
            var resultAfterDeletion = _context.Departments.Remove(departmentToDeletion);
            await _context.SaveChangesAsync();
            return resultAfterDeletion;
        }
    }
}