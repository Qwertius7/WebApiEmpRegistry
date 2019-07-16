using System;
using Repository.dto;

namespace WebApiEmpRegistry
{
    public class EmployeeGetModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public DepartmentDto Department { get; set; }

        public EmployeeGetModel() {}

        public EmployeeGetModel(EmployeeDto emp)
        {
            Id = emp.Id;
            FirstName = emp.FirstName;
            LastName = emp.LastName;
        }
    }
}