using System;
using System.IO;
using data.models;

namespace ApplicationLayer.dto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Guid DepartmentId { get; set; }

        public EmployeeDto() {}

        public EmployeeDto(Employee emp)
        {
            if (emp == null) throw new InvalidDataException("Entered employee is not correct");
            Id = emp.Id;
            FirstName = emp.FirstName;
            LastName = emp.LastName;
            DepartmentId = emp.Department?.Id ?? Guid.Empty;
        }
    }
}