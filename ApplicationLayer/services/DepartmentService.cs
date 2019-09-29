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

        public async Task<IList<DepartmentDto>> GetAllDepartments()
        {
            var deps = await _repo.GetAllDepartments();
            return _mapper.Map<IList<Department>, IList<DepartmentDto>>(deps);
        }

        public async Task<DepartmentDto> GetDepartmentById(Guid id)
        {
            var selectedDep = await _repo.GetDepartmentById(id);
            return _mapper.Map<DepartmentDto>(selectedDep);
        }

        public async Task<DepartmentDto> CreateDepartment(DepartmentDto dep)
        {
            if (dep == null) throw new ArgumentException(nameof(dep));
            var checkedDepartment = await _repo.GetDepartmentById(dep.Id);
            if (checkedDepartment != null) throw new ArgumentException(nameof(dep));
            var creationResult = await _repo.SaveDepartment(_mapper.Map<Department>(dep));
            return _mapper.Map<DepartmentDto>(creationResult);
        }

        public async Task<DepartmentDto> UpdateDepartment(DepartmentDto dep)
        {
            if (dep == null) throw new ArgumentException(nameof(dep));
            var selectedDepartment = await _repo.GetDepartmentById(dep.Id);
            if (selectedDepartment == null) throw new ArgumentException(nameof(dep));
            selectedDepartment.Title = dep.Title;
            var updatedResult = await _repo.SaveDepartment(_mapper.Map<Department>(selectedDepartment));
            return _mapper.Map<DepartmentDto>(updatedResult);
        }

        public async Task DeleteDepartmentById(Guid id)
        {
            var departmentToDeletion = await _repo.GetDepartmentById(id);
            if (departmentToDeletion == null)
            {
                throw new ArgumentException(nameof(id));
            }
            await _repo.DeleteDepartmentById(departmentToDeletion);
        }
    }
}