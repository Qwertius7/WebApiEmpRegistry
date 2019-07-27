using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data.models
{
    public class Department
    {
        private IList<Employee> _employees;
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }

        public IList<Employee> Employees
        {
            get { return _employees ?? new List<Employee>(); }
            protected set { _employees = value; }
        }
    }
}