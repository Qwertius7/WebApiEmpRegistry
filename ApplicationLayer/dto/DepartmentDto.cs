using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.dto
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}