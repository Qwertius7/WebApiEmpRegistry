using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLayer.dto;

namespace ApplicationLayer.interfaces
{
    public interface IProjectService
    {
        Task<ProjectRoleDto> CreateProjectRole(ProjectRoleDto projectRole);
        Task<ProjectMemberDto> CreateProjectMember(ProjectMemberDto projectMember);
        Task<ProjectTeamDto> CreateProjectTeam(ProjectTeamDto projectTeam);
        
        Task<IEnumerable<ProjectRoleDto>> GetAllProjectRoles();
        Task<IEnumerable<ProjectMemberDto>> GetAllProjectMembers();
        Task<IEnumerable<ProjectTeamDto>> GetAllProjectTeams();
    }
}