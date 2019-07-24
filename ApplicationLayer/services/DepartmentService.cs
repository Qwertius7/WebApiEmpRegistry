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

        public DepartmentService() {}

        public DepartmentService(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
        {
            return Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(await _repo.GetAllDepartments());
        }

        public async Task<DepartmentDto> GetDepartmentById(Guid id)
        {
            return Mapper.Map<DepartmentDto>(await _repo.GetDepartmentById(id));
        }

        public async Task<DepartmentDto> CreateDepartment(DepartmentDto dep)
        {
            return Mapper.Map<DepartmentDto>(await _repo.CreateDepartment(Mapper.Map<Department>(dep)));
        }

        public async Task<DepartmentDto> UpdateDepartment(DepartmentDto dep)
        {
            return Mapper.Map<DepartmentDto>(await _repo.UpdateDepartment(Mapper.Map<Department>(dep)));
        }

        public async Task<DepartmentDto> DeleteDepartmentById(Guid id)
        {
            return Mapper.Map<DepartmentDto>(await _repo.DeleteDepartmentById(id));
        }
    }
}