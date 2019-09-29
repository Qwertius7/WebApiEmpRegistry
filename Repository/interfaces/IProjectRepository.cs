using System.Collections.Generic;
using System.Threading.Tasks;
using data.models;

namespace Repository.interfaces
{
    public interface IProjectRepository
    {
        Task<ProjectRole> CreateProjectRole(ProjectRole projectRole);
        Task<ProjectMember> CreateProjectMember(ProjectMember projectMember);
        Task<ProjectTeam> CreateProjectTeam(ProjectTeam projectTeam);
        
        Task<IEnumerable<ProjectRole>> GetAllProjectRoles();
        Task<IEnumerable<ProjectMember>> GetAllProjectMembers();
        Task<IEnumerable<ProjectTeam>> GetAllProjectTeams();
    }
}