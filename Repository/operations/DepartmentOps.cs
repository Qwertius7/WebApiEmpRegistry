using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.IO;
using System.Linq;
using data.models;
using Repository.dto;
using Repository.operations.interfaces;

namespace Repository.operations
{
    public class DepartmentOps : DbOps<DepartmentDto>
    {
        public override IEnumerable<DepartmentDto> GetAll()
        {
            var resultDepartments = new List<DepartmentDto>();
            foreach (var dep in Context.Departments)
            {
                resultDepartments.Add(new DepartmentDto(dep));
            }

            return resultDepartments;
        }

        public override DepartmentDto GetById(Guid id)
        {
            var foundDep = Context.Departments.Find(id);
            if (foundDep == null) throw new ObjectNotFoundException();
            return new DepartmentDto(foundDep);
        }

        public override DepartmentDto Create(DepartmentDto dep)
        {
            var newDep = new Department() {Id = dep.Id, Title = dep.Title, Employees = new List<Employee>()};
            Context.Departments.Add(newDep);
            Context.SaveChanges();
            return dep;
        }

        public override DepartmentDto Update (DepartmentDto dep)
        {
            var selectedDepartment = Context.Departments.SingleOrDefault(d => d.Id == dep.Id);
            if (selectedDepartment == null) throw new InvalidDataException();
            var depNewData = new Department() {Id = dep.Id, Title = dep.Title};
            selectedDepartment.ModifyWithNewParameters(depNewData);
            Context.SaveChanges();
            return dep;
        }

        public override DepartmentDto DeleteById(Guid id)
        {
            if (!Context.Departments.Any(e => e.Id == id)) throw new ObjectNotFoundException();
            foreach (var emp in Context.Employees)
            {
                emp.Department = null;
            }
            var result = new DepartmentDto(Context.Departments.Remove(
                Context.Departments.Single(e => e.Id == id)));
            Context.SaveChanges();
            return result;
        }
    }
}