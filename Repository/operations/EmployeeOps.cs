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
    public class EmployeeOps : DbOps<EmployeeDto>
    {
        public override IEnumerable<EmployeeDto> GetAll()
        {
            var resultEmployees = new List<EmployeeDto>();
            foreach (var emp in Context.Employees.Include("Department"))
            {
                resultEmployees.Add(new EmployeeDto(emp));
            }

            return resultEmployees;
        }

        public override EmployeeDto GetById(Guid id)
        {
            var foundEmp = Context.Employees.Include("Department").SingleOrDefault(e => e.Id == id);
            if (foundEmp == null) throw new ObjectNotFoundException();
            return new EmployeeDto(foundEmp);
        }

        public override EmployeeDto Create(EmployeeDto emp)
        {
            var depForEmployee = Context.Departments.SingleOrDefault(d => d.Id == emp.DepartmentId);
            if (depForEmployee == null) throw new InvalidDataException();
            var newEmp = new Employee() {Id = emp.Id, FirstName = emp.FirstName, LastName = emp.LastName, 
                Department = depForEmployee};
            Context.Employees.Add(newEmp);
            Context.SaveChanges();
            return emp;
        }

        public override EmployeeDto Update (EmployeeDto emp)
        {
            var selectedEmployee = Context.Employees.Include("Department").SingleOrDefault(e => e.Id == emp.Id);
            if (selectedEmployee == null) throw new ObjectNotFoundException();
            var selectedDep = Context.Departments.SingleOrDefault(d => d.Id == emp.DepartmentId);
            if (selectedDep == null) throw new InvalidDataException();
            var empNewData = new Employee() {Id = emp.Id, FirstName = emp.FirstName, LastName = emp.LastName, 
                Department = selectedDep};
            selectedEmployee.ModifyWithNewParameters(empNewData);
            Context.SaveChanges();
            return emp;
        }

        public override EmployeeDto DeleteById(Guid id)
        {
            if (!Context.Employees.Any(e => e.Id == id)) throw new ObjectNotFoundException();
            var resultAfterDeletion = new EmployeeDto(Context.Employees.Remove(
                Context.Employees.Single(e => e.Id == id)));
            Context.SaveChanges();
            return resultAfterDeletion;
        }
    }
}