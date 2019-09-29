using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.dto
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DepartmentDto dto &&
                   Id.Equals(dto.Id) &&
                   Title == dto.Title;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}