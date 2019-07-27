using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data.models
{
    public class Employee
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Guid? DepartmentId { get; protected set; }
        public Department Department { get; protected set; }

        public void SetDepartment(Department dep)
        {
            if (dep == null) throw new Exception("Dep can't be null");
//            Contract.Requires(Department != null);
            this.DepartmentId = dep.Id;
            this.Department = dep;
        }
    }
}