using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.dto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }
    }
}