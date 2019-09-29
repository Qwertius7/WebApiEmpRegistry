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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmpRegistryContext _context;

        public DepartmentRepository() {}

        public DepartmentRepository(EmpRegistryContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        
        public Task<List<Department>> GetAllDepartments()
        {
            return _context.Departments.Include(d => d.Employees).ToListAsync();
        }

        public Task<Department> GetDepartmentById(Guid id)
        {
            return _context.Departments.Include(d => d.Employees).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Department> SaveDepartment(Department dep)
        {
            if (dep == null)
            {
                throw new ArgumentException(nameof(dep));
            }
            _context.Departments.AddOrUpdate(dep);
            await _context.SaveChangesAsync();
            return dep;
        }

        public async Task DeleteDepartmentById(Department dep)
        {
            // All employees are left without department here
            // TODO: create and apply some business rules here to move them to another department

            var resultAfterDeletion = _context.Departments.Remove(dep);
            await _context.SaveChangesAsync();
        }
    }
}