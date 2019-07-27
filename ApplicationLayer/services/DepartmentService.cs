using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLayer.dto;
using ApplicationLayer.interfaces;
using AutoMapper;
using data.models;
using Repository.interfaces;

namespace ApplicationLayer.services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repo;
        private readonly IMapper _mapper;

        public DepartmentService() {}

        public DepartmentService(IDepartmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
        {
            return _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(await _repo.GetAllDepartments());
        }

        public async Task<DepartmentDto> GetDepartmentById(Guid id)
        {
            return _mapper.Map<DepartmentDto>(await _repo.GetDepartmentById(id));
        }

        public async Task<DepartmentDto> CreateDepartment(DepartmentDto dep)
        {
            return _mapper.Map<DepartmentDto>(await _repo.CreateDepartment(_mapper.Map<Department>(dep)));
        }

        public async Task<DepartmentDto> UpdateDepartment(DepartmentDto dep)
        {
            var selectedDepartment = _mapper.Map<DepartmentDto>(await GetDepartmentById(dep.Id));
            return selectedDepartment == null ? null : 
                _mapper.Map<DepartmentDto>(await _repo.UpdateDepartment(_mapper.Map<Department>(dep)));
        }

        public async Task<DepartmentDto> DeleteDepartmentById(Guid id)
        {
            
            var departmentToDeletion = await GetDepartmentById(id);
            return departmentToDeletion == null ? null : 
                _mapper.Map<DepartmentDto>(await _repo.DeleteDepartmentById(id));
        }
    }
}