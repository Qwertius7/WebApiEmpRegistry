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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IDepartmentRepository _depRepo;
        private readonly IMapper _mapper;
        
        public EmployeeService() {}

        public EmployeeService(IEmployeeRepository repo, IDepartmentRepository depRepo, IMapper mapper)
        {
            _repo = repo;
            _depRepo = depRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(await _repo.GetAllEmployees());
        }

        public async Task<EmployeeDto> GetEmployeeById(Guid id)
        {
            return _mapper.Map<EmployeeDto>(await _repo.GetEmployeeById(id));
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeDto emp)
        {
            return _mapper.Map<EmployeeDto>(await _repo.CreateEmployee(_mapper.Map<Employee>(emp)));
        }

        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto emp)
        {
            var selectedEmployee = await GetEmployeeById(emp.Id);
            var depForEmployee = await _depRepo.GetDepartmentById(emp.DepartmentId);
            if (selectedEmployee == null || depForEmployee == null) return null;
            return _mapper.Map<EmployeeDto>(await _repo.UpdateEmployee(_mapper.Map<Employee>(emp)));
        }

        public async Task<EmployeeDto> DeleteEmployeeById(Guid id)
        {
            var employeeToDeletion = await GetEmployeeById(id);
            return employeeToDeletion == null ? null : 
                _mapper.Map<EmployeeDto>(await _repo.DeleteEmployeeById(id));
        }
    }
}