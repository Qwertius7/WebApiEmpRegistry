using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data.models
{
    public class ProjectRole
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RoleId { get; set; }
        
        [Required]
        public string RoleTitle { get; set; }
        public string RoleDescription { get; set; }
    }
}