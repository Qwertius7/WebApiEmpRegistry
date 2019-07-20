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
        
        protected DepartmentRepository()
        {
            _context = new EmpRegistryContext();
        }
        
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(Guid id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<Department> CreateDepartment(Department dep)
        {
            _context.Departments.Add(dep);
            await _context.SaveChangesAsync();
            return dep;
        }

        public async Task<Department> UpdateDepartment(Department dep)
        {
            var selectedDepartment = await _context.Departments.SingleOrDefaultAsync(d => d.Id == dep.Id);
            if (selectedDepartment == null) return null;
            selectedDepartment.Title = dep.Title;
            selectedDepartment.Employees = dep.Employees;
            await _context.SaveChangesAsync();
            return dep;
        }

        public async Task<Department> DeleteDepartmentById(Guid id)
        {
            if (!await _context.Departments.AnyAsync(e => e.Id == id)) return null;
            foreach (var emp in _context.Employees)
            {
                emp.Department = null;
            }
            var result = _context.Departments.Remove(_context.Departments.Single(e => e.Id == id));
            await _context.SaveChangesAsync();
            return result;
        }
    }
}