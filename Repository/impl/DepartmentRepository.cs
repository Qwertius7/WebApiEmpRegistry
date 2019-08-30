using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            _context.Departments.Add(dep);
            await _context.SaveChangesAsync();
            return dep;
        }

        public async Task<Department> UpdateDepartment(Department dep)
        {
            var selectedDepartment = await _context.Departments.SingleAsync(e => e.Id == dep.Id);
            selectedDepartment.Title = dep.Title;
            await _context.SaveChangesAsync();
            return dep;
        }

        public async Task<Department> DeleteDepartmentById(Guid id)
        {
            var departmentToDeletion = await _context.Departments.Include(d => d.Employees).SingleAsync(d => d.Id == id);
            // All employees are left without department here
            // TODO: create and apply some business rules here to move them to another department
            
            var resultAfterDeletion = _context.Departments.Remove(departmentToDeletion);
            await _context.SaveChangesAsync();
            return resultAfterDeletion;
        }
    }
}