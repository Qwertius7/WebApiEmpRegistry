using ApplicationLayer.dto;
using AutoMapper;
using data.models;

namespace ApplicationLayer.config.automapper
{
    public class DomainDtoProfile : Profile
    {
        public DomainDtoProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<ProjectRole, ProjectRoleDto>();
            CreateMap<ProjectMember, ProjectMemberDto>();
            CreateMap<ProjectTeam, ProjectTeamDto>();
            AllowNullCollections = true;
        }
    }
}