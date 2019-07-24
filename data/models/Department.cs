using System;
using System.Collections.Generic;

namespace data.models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}