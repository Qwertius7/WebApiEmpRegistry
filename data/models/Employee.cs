using System;

namespace data.models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Department Department { get; set; }

        public override string ToString()
        {
            return $"Employee {Id}:\n\t{FirstName} {LastName}\n\tDepartment: {Department}";
        }
        
        public Employee ModifyWithNewParameters(Employee newOne)
        {
            if (this.Id != newOne.Id) return this;
            this.FirstName = newOne.FirstName;
            this.LastName = newOne.LastName;
            this.Department = newOne.Department;
            return this;
        }
    }
}