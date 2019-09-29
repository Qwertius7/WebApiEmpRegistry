using System;

namespace ApplicationLayer.dto
{
    public class ProjectRoleDto
    {
        public Guid RoleId { get; set; }
        public string RoleTitle { get; set; }
        public string RoleDescription { get; set; }
    }
}