using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using data;
using data.models;
using Repository.interfaces;

namespace Repository.impl
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly EmpRegistryContext _context;

        public ProjectRepository(EmpRegistryContext context)
        {
            _context = context;
        }

        public async  Task<ProjectRole> CreateProjectRole(ProjectRole projectRole)
        {
            var opResult = _context.ProjectRoles.Add(projectRole);
            await _context.SaveChangesAsync();
            return opResult;
        }

        public async Task<ProjectMember> CreateProjectMember(ProjectMember projectMember)
        {
            var opResult = _context.ProjectMembers.Add(projectMember);
            await _context.SaveChangesAsync();
            return opResult;
        }

        public async Task<ProjectTeam> CreateProjectTeam(ProjectTeam projectTeam)
        {
            var opResult = _context.ProjectTeams.Add(projectTeam);
            await _context.SaveChangesAsync();
            return opResult;
        }

        public async Task<IEnumerable<ProjectRole>> GetAllProjectRoles()
        {
            return await _context.ProjectRoles.ToListAsync();
        }

        public async Task<IEnumerable<ProjectMember>> GetAllProjectMembers()
        {
            return await _context.ProjectMembers.ToListAsync();
        }

        public async Task<IEnumerable<ProjectTeam>> GetAllProjectTeams()
        {
            return await _context.ProjectTeams.ToListAsync();
        }
    }
}