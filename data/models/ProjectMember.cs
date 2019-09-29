using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace data.models
{
    public class ProjectMember
    {
        private IList<ProjectRole> _projectRoles;
        
        [Key]
        [Required]
        public Guid ParticipantId { get; set; }
        public Employee ProjectParticipant { get; set; }
        public decimal ProjectWorkingTimePart { get; set; }

        public Guid? ProjectTeamId { get; protected set; }
        public ProjectTeam ProjectTeam { get; protected set; }
        
        public IList<ProjectRole> ProjectRoles
        {
            get { return _projectRoles ?? new List<ProjectRole>(); }
            set { _projectRoles = value; }
        }

        public void SetProjectTeam(ProjectTeam projectTeam)
        {
            if (projectTeam == null) throw new Exception("Project team entity can't be null'");
            this.ProjectTeamId = projectTeam.ProjectTeamId;
            this.ProjectTeam = projectTeam;
        }
    }
}