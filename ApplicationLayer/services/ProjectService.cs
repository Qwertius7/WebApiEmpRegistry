using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLayer.dto;
using ApplicationLayer.interfaces;
using AutoMapper;
using data.models;
using Repository.interfaces;

namespace ApplicationLayer.services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectRoleDto> CreateProjectRole(ProjectRoleDto projectRole)
        {
            return _mapper.Map<ProjectRoleDto>(
                await _projectRepository.CreateProjectRole(_mapper.Map<ProjectRole>(projectRole)));
        }

        public async Task<ProjectMemberDto> CreateProjectMember(ProjectMemberDto projectMember)
        {
            return _mapper.Map<ProjectMemberDto>(
                await _projectRepository.CreateProjectMember(_mapper.Map<ProjectMember>(projectMember)));
        }

        public async Task<ProjectTeamDto> CreateProjectTeam(ProjectTeamDto projectTeam)
        {
            return _mapper.Map<ProjectTeamDto>(
                await _projectRepository.CreateProjectTeam(_mapper.Map<ProjectTeam>(projectTeam)));
        }

        public async Task<IEnumerable<ProjectRoleDto>> GetAllProjectRoles()
        {
            return _mapper.Map<IEnumerable<ProjectRoleDto>>(await _projectRepository.GetAllProjectRoles());
        }

        public async Task<IEnumerable<ProjectMemberDto>> GetAllProjectMembers()
        {
            return _mapper.Map<IEnumerable<ProjectMemberDto>>(await _projectRepository.GetAllProjectMembers());
        }

        public async Task<IEnumerable<ProjectTeamDto>> GetAllProjectTeams()
        {
            return _mapper.Map<IEnumerable<ProjectTeamDto>>(await _projectRepository.GetAllProjectTeams());
        }
    }
}