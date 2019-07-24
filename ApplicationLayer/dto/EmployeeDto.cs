using System;

namespace ApplicationLayer.dto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DepartmentDto Department { get; set; }
    }
}