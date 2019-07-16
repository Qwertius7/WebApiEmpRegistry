using System;
using System.IO;
using data.models;

namespace Repository.dto
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public DepartmentDto() {}
        public DepartmentDto(Department d)
        {
            if (d == null) throw new InvalidDataException("Bad state of Department object");
            Id = d.Id;
            Title = d.Title;
        }
    }
}