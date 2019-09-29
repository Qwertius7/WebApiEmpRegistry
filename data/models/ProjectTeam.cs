using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data.models
{
    public class ProjectTeam
    {
        private IList<ProjectMember> _projectMembers;
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectTeamId { get; set; }
        [Required]
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        
        public IList<ProjectMember> ProjectMembers
        {
            get { return _projectMembers ?? new List<ProjectMember>(); }
            set { _projectMembers = value; }
        }
    }
}