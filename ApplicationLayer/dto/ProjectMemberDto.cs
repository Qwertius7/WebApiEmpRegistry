using System;
using System.Collections.Generic;

namespace ApplicationLayer.dto
{
    public class ProjectMemberDto
    {
        public Guid ParticipantId { get; set; }
        public EmployeeDto ProjectParticipant { get; set; }
        public decimal ProjectWorkingTimePart { get; set; }
        public IList<ProjectRoleDto> ProjectRoles { get; set; }

        public Guid ProjectTeamId { get; set; }
        public ProjectTeamDto ProjectTeamDto { get; set; }
    }
}