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
    }
}