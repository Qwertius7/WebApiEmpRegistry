using System;

namespace ApplicationLayer.dto
{
    public class ProjectTeamDto
    {
        public Guid ProjectTeamId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
    }
}