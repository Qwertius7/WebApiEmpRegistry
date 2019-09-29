using ApplicationLayer.dto;
using AutoMapper;
using data.models;

namespace ApplicationLayer.config.automapper
{
    public class DtoDomainProfile : Profile
    {
        public DtoDomainProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<ProjectRoleDto, ProjectRole>();
            CreateMap<ProjectMemberDto, ProjectMember>();
            CreateMap<ProjectTeamDto, ProjectTeam>();
        }
    }
}