using System;
using System.Collections.Generic;
using Repository.dto;
using Repository.interfaces;
using Repository.operations.interfaces;

namespace Repository.impl
{
    public class GenericDbRepository : IGenericRepository
    {
        private readonly DbOps<EmployeeDto> _employees;
        private readonly DbOps<DepartmentDto> _departments;

        public GenericDbRepository(DbOps<EmployeeDto> employee, DbOps<DepartmentDto> departments)
        {
            _employees = employee;
            _departments = departments;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            return _departments.GetAll();
        }

        public DepartmentDto GetDepartmentById(Guid id)
        {
            return _departments.GetById(id);
        }

        public DepartmentDto CreateDepartment(DepartmentDto dep)
        {
            return _departments.Create(dep);
        }

        public DepartmentDto UpdateDepartment(DepartmentDto dep)
        {
            return _departments.Update(dep);
        }

        public DepartmentDto DeleteDepartmentById(Guid id)
        {
            return _departments.DeleteById(id);
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            return _employees.GetAll();
        }

        public EmployeeDto GetEmployeeById(Guid id)
        {
            return _employees.GetById(id);
        }

        public EmployeeDto CreateEmployee(EmployeeDto emp)
        {
            return _employees.Create(emp);
        }

        public EmployeeDto UpdateEmployee(EmployeeDto emp)
        {
            return _employees.Update(emp);
        }

        public EmployeeDto DeleteEmployeeById(Guid id)
        {
            return _employees.DeleteById(id);
        }
    }
}